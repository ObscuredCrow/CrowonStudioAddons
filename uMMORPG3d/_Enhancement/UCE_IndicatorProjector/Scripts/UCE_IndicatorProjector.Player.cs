// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;
using System;
using System.Linq;
using System.Collections;

// PLAYER

public partial class Player
{
    // -----------------------------------------------------------------------------------
    // OnSelect_UCE_IndicatorProjector
    // @Client
    // -----------------------------------------------------------------------------------
    [Client]
    [DevExtMethods("OnSelect")]
    private void OnSelect_UCE_IndicatorProjector(Entity entity)
    {
        if (entity != null &&
            entity.GetComponent<UCE_IndicatorProjector>() != null &&
            UCE_InteractableObject.ClosestDistance(collider, entity.collider) <= interactionRange &&
            state == "IDLE"
            )
        {
            UCE_IndicatorProjector ip = entity.GetComponent<UCE_IndicatorProjector>();

            ip.Show();
        }
    }

    // -----------------------------------------------------------------------------------
}