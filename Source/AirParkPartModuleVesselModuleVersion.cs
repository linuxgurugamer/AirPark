using System;
using UnityEngine;
#if false
namespace AirPark
{
    public class AirPark : PartModule
    {
        APVesselModule apvm;

#region Fields / Globals
        [KSPField(isPersistant = false, guiActive = true, guiName = "AirParked")]
        public  Boolean Parked;


        [KSPField(isPersistant = false, guiActive = true, guiName = "Auto UnPark")]
        public  Boolean autoPark;


        //Vessel State
        [KSPField(isPersistant = false, guiActive = true)] //flip to false guiactive on release
        Vessel.Situations previousState;


#region Debug Fields

        [KSPField(guiActive = true, isPersistant = false, guiName = "Current Situation")]
        public string vesselSituation;

#endregion DebugFields

#endregion

#region Toggles
        [KSPEvent(guiActive = true, guiName = "Toggle Park")]
        public void TogglePark_Event()
        {
            apvm.TogglePark();
        }

        [KSPAction("Toggle Park on/off")]
        public void TogglePart_AG(KSPActionParam param)
        {
            apvm.TogglePark();
        }


        [KSPEvent(guiActive = true, guiName = "Toggle Auto UnPark")] //auto park on will awake the vessel and set Parked = false if closer than 1.5 KM and inactive
        public void ToggleAutoPark()
        {
            apvm.ToggleAutoPark();
        }
#endregion

        public void Start()
        {
            apvm = FlightGlobals.ActiveVessel.FindVesselModuleImplementing<APVesselModule>();
        }

        void FixedUpdate()
        {
            Parked = apvm.Parked;
            autoPark = APVesselModule.autoPark;
            previousState = apvm.previousState;
            vesselSituation = apvm.vesselSituation;
        }
    }
}
#endif