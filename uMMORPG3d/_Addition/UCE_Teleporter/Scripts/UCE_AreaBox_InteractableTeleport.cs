// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// UCE AREA (BOX) INTERACTABLE TELEPORT

[RequireComponent(typeof(BoxCollider))]
public class UCE_AreaBox_InteractableTeleport : UCE_InteractableAreaBox
{
    [Header("[-=-=-=- UCE TELEPORTER -=-=-=-]")]
    [Tooltip("[Required] Any on scene Transform or GameObject OR off scene coordinates (requires UCE Network Zones AddOn)")]
    public UCE_TeleportationTarget teleportationTarget;

    // -----------------------------------------------------------------------------------
    // OnInteractServer
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    public override void OnInteractServer(Player player)
    {
        teleportationTarget.OnTeleport(player);
    }

    // -----------------------------------------------------------------------------------
}