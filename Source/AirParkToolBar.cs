//Code Adapted from https://github.com/BahamutoD/VesselMover/blob/master/VesselMoverToolbar.cs

using System;
using System.Collections;
using UnityEngine;
using KSP.UI.Screens;
using ToolbarControl_NS;
using ClickThroughFix;
using SpaceTuxUtility;

namespace AirPark
{
#if true

    [KSPAddon(KSPAddon.Startup.Flight, false)]
    class AirParkToolbar : MonoBehaviour
    {
        internal const string MODID = "AirPark";
        internal const string MODNAME = "AirPark";
        static internal ToolbarControl toolbarControl = null;

        public static bool hasAddedButton = false;
        public static bool toolbarGuiEnabled = false;

        Rect toolbarRect;
        float toolbarWidth = 280;
        float toolbarHeight = 110;
        float toolbarMargin = 6;
        float toolbarLineHeight = 20;
        float contentWidth;
        Vector2 toolbarPosition;
        Rect svRectScreenSpace;
        AirPark activeVesselAirPark;
        void VesselChange(Vessel v)
        {
            if (!v.isActiveVessel)
            {
                activeVesselAirPark = null;
                return;
            }
            activeVesselAirPark = FlightGlobals.ActiveVessel.FindPartModuleImplementing<AirPark>();
        }

        void Start()
        {
            toolbarPosition = new Vector2(Screen.width - toolbarWidth - 80, 50);
            toolbarRect = new Rect(toolbarPosition.x, toolbarPosition.y + 100, toolbarWidth, toolbarHeight);
            contentWidth = toolbarWidth - (2 * toolbarMargin);

            AddToolbarButton();

            activeVesselAirPark = FlightGlobals.ActiveVessel.FindPartModuleImplementing<AirPark>();
            GameEvents.onVesselChange.Add(VesselChange);
        }

        GUIStyle centerLabelStyle = null;
        int winId = SpaceTuxUtility.WindowHelper.NextWindowId("AirParkToolbar");
        void OnGUI()
        {
            if (toolbarGuiEnabled) //&& AirParkPM.instance)
            {
                if (centerLabelStyle == null)
                    centerLabelStyle = new GUIStyle(HighLogic.Skin.label) { alignment = TextAnchor.UpperCenter };

                if (!HighLogic.CurrentGame.Parameters.CustomParams<AirParkSettings>().altskin)
                    GUI.skin = HighLogic.Skin;
                toolbarRect = ClickThruBlocker.GUILayoutWindow(winId, toolbarRect, ToolbarWindow, "AirPark");
            }
        }

        void ToolbarWindow(int windowID)
        {
            float line = 0;
            line += 1.25f;

            if (!FlightGlobals.ActiveVessel) { return; }

            if (activeVesselAirPark)
            {
                if (!activeVesselAirPark.Parked)
                {
                    if (GUILayout.Button("Park Vessel", GUILayout.Height(20 * 1.5f)))
                    {
                        if (FlightGlobals.ActiveVessel && !FlightGlobals.ActiveVessel.Landed)
                            activeVesselAirPark.TogglePark();
                    }

                }
                else
                {
                    if (GUILayout.Button("Un-Park", GUILayout.Height(20 * 2f)))
                    {
                        activeVesselAirPark.TogglePark();
                    }
                }

                line += 0.2f;
                Rect spawnVesselRect = LineRect(ref line);
                svRectScreenSpace = new Rect(spawnVesselRect);
                svRectScreenSpace.x += toolbarRect.x;
                svRectScreenSpace.y += toolbarRect.y;

                if (!HighLogic.CurrentGame.Parameters.CustomParams<AirParkSettings>().autoPark)
                {
                    if (GUILayout.Button("Auto-Park OFF", GUILayout.Height(spawnVesselRect.height)))
                    {
                        HighLogic.CurrentGame.Parameters.CustomParams<AirParkSettings>().autoPark = true;
                        SetAutoParkTexture();
                    }
                }
                else
                {
                    if (GUILayout.Button("Auto-Park ON", GUILayout.Height(spawnVesselRect.height)))
                    {
                        HighLogic.CurrentGame.Parameters.CustomParams<AirParkSettings>().autoPark = false;
                        SetAutoParkTexture();
                    }
                }
            }
            else
            {
                GUILayout.Label("No AirPark Module Found", centerLabelStyle);
            }

            GUI.DragWindow();
        }

        internal static void SetAutoParkTexture()
        {
            if (HighLogic.CurrentGame.Parameters.CustomParams<AirParkSettings>().autoPark == false)
                toolbarControl.SetTexture("AirPark/PluginData/Icon/AirPark-38", "AirPark/PluginData/Icon/AirPark-24");
            else
                toolbarControl.SetTexture("AirPark/PluginData/Icon/AirParkOn-38", "AirPark/PluginData/Icon/AirParkOn-24");
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
                        "AirPark/PluginData/Icon/AirPark-38",
                        "AirPark/PluginData/Icon/AirPark-24",
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

        public static bool MouseIsInRect(Rect rect)
        {
            return rect.Contains(MouseGUIPos());
        }

        public static Vector2 MouseGUIPos()
        {
            return new Vector3(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 0);
        }
    }
#endif
}