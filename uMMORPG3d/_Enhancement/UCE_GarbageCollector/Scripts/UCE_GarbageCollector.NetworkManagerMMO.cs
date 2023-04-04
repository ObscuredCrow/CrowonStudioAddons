// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;
using UnityEngine;
using Mirror;

// NetworkManagerMMO

public partial class NetworkManagerMMO
{
    // -----------------------------------------------------------------------------------
    // OnStartServer_UCE_GarbageCollector
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnStartServer")]
    private void OnStartServer_UCE_GarbageCollector()
    {
        Invoke("UCE_GarbageCollection", 3);
    }

    // -----------------------------------------------------------------------------------
    // OnServerDisconnect_UCE_GarbageCollector
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnServerDisconnect")]
    private void OnServerDisconnect_UCE_GarbageCollector(NetworkConnection conn)
    {
        if (Player.onlinePlayers.Count <= 1)
            UCE_GarbageCollection();
    }

    // -----------------------------------------------------------------------------------
    // UCE_GarbageCollection
    // -----------------------------------------------------------------------------------
    protected void UCE_GarbageCollection()
    {
        System.GC.Collect();
        Debug.Log("System Garbage Collection called...");
    }

    // -----------------------------------------------------------------------------------
}