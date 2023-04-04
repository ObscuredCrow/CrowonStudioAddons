// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// MONSTER

public partial class Monster
{
    [Header("-=-=- UCE Drop Chances -=-=-")]
    public UCE_ItemDropChance[] UCE_dropChances;

    // -----------------------------------------------------------------------------------
    // OnDeath_UCE_DropChances
    // -----------------------------------------------------------------------------------
    [Server]
    [DevExtMethods("OnDeath")]
    private void OnDeath_UCE_DropChances()
    {
        if (lastAggressor == null || !(lastAggressor is Player) || UCE_dropChances.Length == 0) return;

        foreach (UCE_ItemDropChance itemChance in UCE_dropChances)
        {
            if (itemChance.dropRequirements.CheckRequirements((Player)lastAggressor))
            {
                if (Random.value <= itemChance.probability)
                    inventory.Add(new ItemSlot(new Item(itemChance.item)));
            }
        }
    }

    // -----------------------------------------------------------------------------------
}