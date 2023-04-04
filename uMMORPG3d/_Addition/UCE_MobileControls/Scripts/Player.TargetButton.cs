// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// Player

partial class Player
{
    [HideInInspector] public bool targetButtonPressed = false;

    // simple tab targeting for buttons
    [Client]
    public void TargetNearestButton()
    {
        targetButtonPressed = true;
    }

    public void UpdateClient_MobileControls()
    {
        if ((Input.GetMouseButtonDown(0) || UCE_Tools.GetTouchDown) && !Utils.IsCursorOverUserInterface())
            UCE_Tools.pointerDown = true;
    }
}