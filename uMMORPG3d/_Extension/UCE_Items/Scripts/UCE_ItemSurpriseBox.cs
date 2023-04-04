// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// SURPRISE BOX ITEM

[CreateAssetMenu(menuName = "UCE/Item/Surprise Box", order = 0)]
public class UCE_ItemSurpriseBox : UsableItem
{
    [Header("[-=-=-=- UCE Surprise Box Item -=-=-=-]")]
    public UCE_InteractionRewards rewards;

    [Tooltip("Decrease amount by how many each use (can be 0)?")]
    public int decreaseAmount = 1;

    [Tooltip("Message shown if there is not enough free space in inventory.")]
    public string failMessage = "You cannot use that right now!";

    // -----------------------------------------------------------------------------------
    // Use
    // -----------------------------------------------------------------------------------
    public override void Use(Player player, int inventoryIndex)
    {
        ItemSlot slot = player.inventory[inventoryIndex];

        // -- Only activate if enough charges left and can fit all items
        if (decreaseAmount == 0 || slot.amount >= decreaseAmount)
        {
            if (player.isAlive && player.InventorySlotsFree() >= rewards.items.Length)
            {
                // always call base function too
                base.Use(player, inventoryIndex);

                // -- activate surprise box
                rewards.gainRewards(player);

                // decrease amount
                slot.DecreaseAmount(decreaseAmount);
                player.inventory[inventoryIndex] = slot;
            }
            else
            {
                player.UCE_TargetAddMessage(failMessage);
            }
        }
    }

    // -----------------------------------------------------------------------------------
}