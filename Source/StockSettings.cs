using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using KSP.Localization;



namespace AirPark
{
    // http://forum.kerbalspaceprogram.com/index.php?/topic/147576-modders-notes-for-ksp-12/#comment-2754813
    // search for "Mod integration into Stock Settings
    // HighLogic.CurrentGame.Parameters.CustomParams<AirParkSettings>().
    public class AirParkSettings : GameParameters.CustomParameterNode
    {
        public override string Title { get { return ""; } }
        public override GameParameters.GameMode GameMode { get { return GameParameters.GameMode.ANY; } }
        public override string Section { get { return "AirPark"; } }
        public override string DisplaySection { get { return "AirPark"; } }
        public override int SectionOrder { get { return 1; } }
        public override bool HasPresets { get { return false; } }


        [GameParameters.CustomParameterUI("AutoPark",
            toolTip = "Default setting for AutoPark")]
        public bool autoPark = false;

        [GameParameters.CustomParameterUI("Alternate Skin",
            toolTip = "Use alternate skin")]
        public bool altskin = false;


        [GameParameters.CustomParameterUI("Allow Suborbital Parking",
            toolTip = "Allow vessels that are suborbital to be parked")]
        public bool allowSuborbitalParking = false;



        public override void SetDifficultyPreset(GameParameters.Preset preset)
        { }

        public override bool Enabled(MemberInfo member, GameParameters parameters)
        { return true; }

        public override bool Interactible(MemberInfo member, GameParameters parameters)
        { return true; }

        public override IList ValidValues(MemberInfo member)
        { return null; }
    }

}
