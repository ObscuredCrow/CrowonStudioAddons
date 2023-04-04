// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// MOUNT - ITEM

[CreateAssetMenu(menuName = "UCE/Item/Mount", order = 0)]
public partial class UCE_Tmpl_MountItem : SummonableItem
{
    [Header("[-=-=-=- UCE MOUNT -=-=-=-]")]
    [Tooltip("[Optional] Immediately ride the mount when its summoned?")]
    public bool autoRide;

    [Tooltip("[Optional] Decrease amount by how many each use (can be 0)?")]
    public int decreaseAmount = 1;

    // -----------------------------------------------------------------------------------
    // Use
    // @Server
    // -----------------------------------------------------------------------------------
    public override void Use(Player player, int inventoryIndex)
    {
        ItemSlot slot = player.inventory[inventoryIndex];

        // -- Only activate if enough charges left
        if ((player.state == "IDLE" || player.state == "MOVING") && (decreaseAmount == 0 || slot.amount >= decreaseAmount))
        {
            // always call base function too
            base.Use(player, inventoryIndex);

            // -- Summon Mount
            player.UCE_ToggleMount(inventoryIndex);

            // -- Decrease Amount
            if (decreaseAmount != 0)
            {
                slot.DecreaseAmount(decreaseAmount);
                player.inventory[inventoryIndex] = slot;
            }
        }
    }

    // -----------------------------------------------------------------------------------
}