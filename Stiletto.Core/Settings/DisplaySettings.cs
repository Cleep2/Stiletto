﻿using Stiletto.Attributes;

namespace Stiletto.Settings
{
    public class DisplaySettings
    {
        [FileProperty]
        public string None_Placeholder { get; set; } = "-- NONE --";

        [FileProperty]
        public string Default_Character_Name { get; set; } = "<character_name>";

        [FileProperty]
        public string Default_Heel_Name { get; set; } = "<heel_name>";

        [FileProperty]
        public string Default_Animation_Path { get; set; } = "<animation_name>";

        [FileProperty]
        public string Default_Animation_Name { get; set; } = "<animation_frame>";

        [FileProperty]
        public string Disclaimer { get; set; } = "The following parameters are not saved to the character card, don't forget to click on \"Save Heel Settings\"";

        [FileProperty]
        public string Current_Shoes { get; set; } = "Current shoes: ";

        [FileProperty]
        public string Stiletto { get; set; } = "Stiletto";

        [FileProperty]
        public string Ankle_Toes_Angle { get; set; } = "Ankle + Toes Rotation";

        [FileProperty]
        public string Ankle_Angle { get; set; } = "Ankle Rotation";

        [FileProperty]
        public string Toes_Angle { get; set; } = "Toes Rotation";

        [FileProperty]
        public string Leg_Angle { get; set; } = "Whole Foot Rotation";

        [FileProperty]
        public string Height { get; set; } = "Height";

        [FileProperty]
        public string Save { get; set; } = "Save";

        [FileProperty]
        public string Reload_Configurations { get; set; } = "Reload Heels/Anims Settings";

        [FileProperty]
        public string Toggle_Game_Gui { get; set; } = "Advanced Panel";

        [FileProperty]
        public string Active { get; set; } = "Active";

        [FileProperty]
        public string Toe_Roll { get; set; } = "Toe Roll";

        [FileProperty]
        public string Ankle_Roll { get; set; } = "Ankle Roll";

        [FileProperty]
        public string Knee_Bend { get; set; } = "Knee Bend";

        [FileProperty]
        public string Right_Leg { get; set; } = "Right";

        [FileProperty]
        public string Left_Leg { get; set; } = "Left";

        [FileProperty]
        public string Animation_Tab { get; set; } = "Animation";

        [FileProperty]
        public string CustomPose_Tab { get; set; } = "Custom";

        [FileProperty]
        public string CustomHeel_Tab { get; set; } = "Heel";

        [FileProperty]
        public string ShoeWarp_Tab { get; set; } = "Warp";

        [FileProperty]
        public string Custom_Pose_Compatibility { get; set; } = "Custom Pose (Compatibility)";

        [FileProperty]
        public string Current_Characters { get; set; } = "Current Characters";

        [FileProperty]
        public string All_Characters { get; set; } = "All Characters";

        [FileProperty]
        public string Switch_Characters { get; set; } = "Switch";

        [FileProperty]
        public string Name { get; set; } = "Name";

        [FileProperty]
        public string Heel { get; set; } = "Heel";

        [FileProperty]
        public string Anim_Path { get; set; } = "Anim Path";

        [FileProperty]
        public string Anim_Name { get; set; } = "Anim Name";

        [FileProperty]
        public string Total { get; set; } = "Total";

        [FileProperty]
        public string Previous { get; set; } = "Previous";

        [FileProperty]
        public string Next { get; set; } = "Next";

        [FileProperty]
        public string AnimationSettings { get; set; } = "Animation Settings";

        [FileProperty]
        public string Custom_Pose { get; set; } = "Custom Pose";

        [FileProperty]
        public string Save_Settings { get; set; } = "Save these settings:";

        [FileProperty]
        public string Save_For_All { get; set; } = "For all animations";

        [FileProperty]
        public string Save_For_Animation_Group { get; set; } = "For the whole Animation Path";

        [FileProperty]
        public string Save_For_Animation_Frame { get; set; } = "For this specific Animation Name";

        [FileProperty]
        public string Both_Legs { get; set; } = "Both Legs";

        [FileProperty]
        public string Waist_Angle { get; set; } = "Waist Angle";

        [FileProperty]
        public string Thigh_Angle { get; set; } = "Thigh Rotation";

        [FileProperty]
        public string Shoe_Warp { get; set; } = "Shoe Warp";

        [FileProperty]
        public string Shoe_Angle { get; set; } = "Angle";

        [FileProperty]
        public string Shoe_ScaleX { get; set; } = "Scale X";

        [FileProperty]
        public string Shoe_ScaleY { get; set; } = "Scale Y";

        [FileProperty]
        public string Shoe_ScaleZ { get; set; } = "Scale Z";

        [FileProperty]
        public string Shoe_TranslateY { get; set; } = "Translate Y";

        [FileProperty]
        public string Shoe_TranslateZ { get; set; } = "Translate Z";

        [FileProperty]
        public string Shoe_ShearY { get; set; } = "Shear Y Angle";

        [FileProperty]
        public string Shoe_ShearZ { get; set; } = "Shear Z Angle";

        [FileProperty]
        public string Knee_Bend_Settings { get; set; } = "Knee Bend Settings";

        [FileProperty]
        public string Heels_Settings { get; set; } = "Heels Settings";

        [FileProperty]
        public string Shoe_Warp_Settings { get; set; } = "Shoe Warp Settings";

        [FileProperty]
        public string Save_Heel_Settings { get; set; } = "Save Heels Settings";
    }
}
