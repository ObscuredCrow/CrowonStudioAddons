// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

public class UCE_UI_SettingsVariables : MonoBehaviour
{
    public KeyCode[] keybindings = new KeyCode[] { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.LeftControl,
        KeyCode.Space, KeyCode.LeftAlt, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4,
        KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0, KeyCode.R,
        KeyCode.T, KeyCode.Y, KeyCode.M, KeyCode.C, KeyCode.B, KeyCode.F };

    [HideInInspector] public bool isShowOverhead = true;
    [HideInInspector] public bool isShowChat = true;

    [HideInInspector]
    public bool[] keybindUpdate = new bool[] { false, false, false, false, false, false, false,
     false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
}