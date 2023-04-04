// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using System.Collections.Generic;
using Mirror;

// =======================================================================================
// PLAYER
// =======================================================================================
public partial class Player
{
    private UCE_LimitedZonesManager sharedInstanceManager;

    // -----------------------------------------------------------------------------------
    // Cmd_UCE_teleportPlayerToInstance
    // @Client -> @Server
    // -----------------------------------------------------------------------------------
    [Command]
    public void Cmd_UCE_teleportPlayerToInstance(int index, int instanceCategory, int instanceIndex)
    {
        if (!sharedInstanceManager)
            sharedInstanceManager = FindObjectOfType<UCE_LimitedZonesManager>();

        List<UCE_LimitedZonesEntry> instancesAvailable = sharedInstanceManager.getAvailableSharedInstances(this, instanceCategory);

        instancesAvailable[instanceIndex].payEntranceCost(this);

        UCE_PlayerGroupLocations locations = instancesAvailable[instanceIndex].targetArea.playerGroupLocation[index];

        if (locations.teleportPosition.Length == 0) return;

        index = UnityEngine.Random.Range(0, locations.teleportPosition.Length - 1);

        agent.Warp(locations.teleportPosition[index].position);
    }
}

// =======================================================================================