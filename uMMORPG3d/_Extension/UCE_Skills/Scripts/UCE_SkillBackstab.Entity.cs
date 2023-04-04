// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections;
using Mirror;
using UnityEngine;

public partial class Entity
{
    [ClientRpc]
    public void RpcBackstabStartTeleport(Vector3 position, Vector3 enemyPos)
    {
        LookAtY(enemyPos);
        agent.Warp(position);
    }
}