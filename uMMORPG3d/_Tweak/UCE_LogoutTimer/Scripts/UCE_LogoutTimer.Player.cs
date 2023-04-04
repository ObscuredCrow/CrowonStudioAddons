// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

// LogoutTimer

public partial class Player
{
    [Header("[UCE LOGOUT TIMER]")]
    [Range(1, 9999)] public float logoutWarningTime = 30f;

    [Range(1, 9999)] public float logoutKickTime = 60f;

    protected float _logoutTimer = 0;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    [ClientCallback]
    [DevExtMethods("Update")]
    private void Update_UCE_LogoutTimer()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (player.state == "IDLE")
        {
            _logoutTimer += cacheTimerInterval;
        }
        else
        {
            _logoutTimer = 0;

            if (UCE_UI_LogoutTimer_Popup.singleton)
                UCE_UI_LogoutTimer_Popup.singleton.Hide();
            else
                Debug.LogWarning("You forgot to add UCE_UI_LogoutTimer_Popup to your canvas!");
        }

        if (_logoutTimer > logoutKickTime)
            NetworkManagerMMO.Quit();
        else if (_logoutTimer > logoutWarningTime)
            UCE_UI_LogoutTimer_Popup.singleton.Show();
    }

    // -----------------------------------------------------------------------------------
}