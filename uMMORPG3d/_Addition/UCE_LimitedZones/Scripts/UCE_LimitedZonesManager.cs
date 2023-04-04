// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

// UCE SHARED INSTANCE MANAGER

public class UCE_LimitedZonesManager : MonoBehaviour
{
    public UCE_LimitedZonesEntry[] sharedInstances;

    // -----------------------------------------------------------------------------------
    // getAvailableSharedInstances
    // Retrieve a list of shared instances the player is allowed to see
    // -----------------------------------------------------------------------------------
    public List<UCE_LimitedZonesEntry> getAvailableSharedInstances(Player player, int instanceCategory)
    {
        return sharedInstances.Where(x => x.instanceCategory == instanceCategory && x.canPlayerSee(player)).ToList();
    }

    // -----------------------------------------------------------------------------------
}