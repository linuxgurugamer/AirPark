//Code Adapted from https://github.com/BahamutoD/VesselMover/blob/master/VesselMoverToolbar.cs

using System;
using System.Collections;
using UnityEngine;
using KSP.UI.Screens;
using ToolbarControl_NS;
using ClickThroughFix;

namespace AirPark
{
#if false
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    internal class AirParkToolbar : MonoBehaviour
    {
        APVesselModule apvm;
        Vessel lastVessel;

        internal const string MODID = "AirPark";
        internal const string MODNAME = "AirPark";
        static internal ToolbarControl toolbarControl = null;

        public static bool hasAddedButton = false;
        public static bool toolbarGuiEnabled = false;

        Rect toolbarRect;
        float toolbarWidth = 280;
        float toolbarHeight = 0;
        float toolbarMargin = 6;
        float toolbarLineHeight = 20;
        float contentWidth;
        Vector2 toolbarPosition;
        Rect svRectScreenSpace;

        void VesselChange(Vessel v)
        {
            if (!v.isActiveVessel) return;
        }

        void Start()
        {
            toolbarPosition = new Vector2(Screen.width - toolbarWidth - 80, 50);
            toolbarRect = new Rect(toolbarPosition.x, toolbarPosition.y + 100, toolbarWidth, toolbarHeight);
            contentWidth = toolbarWidth - (2 * toolbarMargin);

            AddToolbarButton();

            GameEvents.onVesselChange.Add(VesselChange);
        }

        void OnGUI()
        {
            if (toolbarGuiEnabled) //&& AirParkPM.instance)
            {
                toolbarRect = ClickThruBlocker.GUIWindow(999666, toolbarRect, ToolbarWindow, "AirPark", HighLogic.Skin.window);
            }
        }

        void ToolbarWindow(int windowID)
        {
            float line = 0;
            line += 1.25f;

            if (!FlightGlobals.ActiveVessel) { return; }
            if (lastVessel != FlightGlobals.ActiveVessel)
            {
                apvm = FlightGlobals.ActiveVessel.FindVesselModuleImplementing<APVesselModule>();
                lastVessel = FlightGlobals.ActiveVessel;
            }
            if (!apvm.Parked)
            {
                if (GUI.Button(LineRect(ref line, 1.5f), "Park Vessel", HighLogic.Skin.button))
                {
                    if (!FlightGlobals.ActiveVessel.Landed)
                        apvm.TogglePark();
                    else
                        ScreenMessages.PostScreenMessage("Cannot Park While Landed", 5.0f, ScreenMessageStyle.UPPER_CENTER);
                }
            }
            else
            {
                if (GUI.Button(LineRect(ref line, 2), "Un-Park", HighLogic.Skin.button))
                {
                    apvm.TogglePark();
                }
            }

            line += 0.2f;
            Rect spawnVesselRect = LineRect(ref line);
            svRectScreenSpace = new Rect(spawnVesselRect);
            svRectScreenSpace.x += toolbarRect.x;
            svRectScreenSpace.y += toolbarRect.y;

            if (!APVesselModule.autoPark)
            {
                if (GUI.Button(spawnVesselRect, "Auto-Park OFF", HighLogic.Skin.button))
                {
                    apvm.ToggleAutoPark();
                    toolbarControl.SetTexture("AirPark/PluginData/Icon/AirParkOn", "AirPark/PluginData/Icon/AirParkOn");
                }

            }
            else
            {
                if (GUI.Button(spawnVesselRect, "Auto-Park ON", HighLogic.Skin.button))
                {
                    apvm.ToggleAutoPark();
                    toolbarControl.SetTexture("AirPark/PluginData/Icon/AirPark", "AirPark/PluginData/Icon/AirPark");
                }
            }

            toolbarRect.height = (line * toolbarLineHeight) + (toolbarMargin * 2);
            GUI.DragWindow();
        }

        Rect LineRect(ref float currentLine, float heightFactor = 1)
        {
            Rect rect = new Rect(toolbarMargin, toolbarMargin + (currentLine * toolbarLineHeight), contentWidth, toolbarLineHeight * heightFactor);
            currentLine += heightFactor + 0.1f;
            return rect;
        }

        void LineLabel(string label, ref float line)
        {
            GUI.Label(LineRect(ref line), label, HighLogic.Skin.label);
        }

        void AddToolbarButton()
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                if (toolbarControl == null)
                {
                    toolbarControl = gameObject.AddComponent<ToolbarControl>();
                    toolbarControl.AddToAllToolbars(ShowToolbarGUI, HideToolbarGUI,
                        ApplicationLauncher.AppScenes.FLIGHT,
                        MODID,
                        "airparkButton",
                        "AirPark/PluginData/Icon/AirPark",
                        "AirPark/PluginData/Icon/AirPark",
                        MODNAME
                    );

                }
            }
        }

        public void ShowToolbarGUI()
        {
            AirParkToolbar.toolbarGuiEnabled = true;
        }

        public void HideToolbarGUI()
        {
            AirParkToolbar.toolbarGuiEnabled = false;
        }
    }
#endif
}
