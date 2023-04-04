// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;
using System.Collections;
using System;

// PLAYER

public partial class Player
{
    [Header("-=-=-=- UCE LEVEL UP NOTICE -=-=-=-")]
    public UCE_PopupClass levelUpNotice;

    // -----------------------------------------------------------------------------------
    // OnLevelUp_UCE_LevelUpNotice
    // -----------------------------------------------------------------------------------
    [Server]
    [DevExtMethods("OnLevelUp")]
    private void OnLevelUp_UCE_LevelUpNotice()
    {
        Target_UCE_ShowPopup(connectionToClient, levelUpNotice.message + level.ToString(), levelUpNotice.iconId, levelUpNotice.soundId);
    }
}