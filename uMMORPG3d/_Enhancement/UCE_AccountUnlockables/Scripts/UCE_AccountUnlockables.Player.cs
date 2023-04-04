// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using System.Linq;
using UnityEngine;

// PLAYER

public partial class Player
{
    [HideInInspector] public SyncListString UCE_accountUnlockables = new SyncListString();

    // -----------------------------------------------------------------------------------
    // UCE_AccountUnlock
    // -----------------------------------------------------------------------------------
    public bool UCE_AccountUnlock(string unlockableName, string message, byte iconId, byte soundId)
    {
        if (!UCE_HasAccountUnlock(unlockableName))
        {
            UCE_accountUnlockables.Add(unlockableName.ToLower());
            UCE_ShowPopup(message + unlockableName, iconId, soundId);
            return true;
        }

        return false;
    }

    // -----------------------------------------------------------------------------------
    // UCE_HasAccountUnlock
    // -----------------------------------------------------------------------------------
    public bool UCE_HasAccountUnlock(string unlockableName)
    {
        if (string.IsNullOrWhiteSpace(unlockableName)) return true;

        return (UCE_accountUnlockables.Any(s => s == unlockableName.ToLower()));
    }

    // -----------------------------------------------------------------------------------
}