// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// INTERACTABLE LOTTERY

public partial class UCE_InteractableLottery : UCE_InteractableObject
{
    [Header("-=-=-=- UCE Lottery Object -=-=-=-")]
    public UCE_InteractionRewards rewards;

    // -----------------------------------------------------------------------------------
    // OnInteractServer
    // @Server
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    public override void OnInteractServer(Player player)
    {
        rewards.gainRewards(player);
    }
}