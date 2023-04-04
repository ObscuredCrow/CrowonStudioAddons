// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// RECIPE ITEM

[CreateAssetMenu(menuName = "UCE/Item/Unlockable Class", order = 0)]
public class UCE_Item_UnlockableClass : UsableItem
{
    [Header("-=-=-=- Unlockable Class Item -=-=-=-")]
    public Player playerClass;

    [Tooltip("Decrease amount by how many each use (can be 0)?")]
    public int decreaseAmount = 1;

    public string unlockPopupMessage = "New class unlocked: ";
    public byte unlockPopupIconID = 0;
    public byte unlockPopupSoundID = 0;

    // -----------------------------------------------------------------------------------
    // Use
    // -----------------------------------------------------------------------------------
    public override void Use(Player player, int inventoryIndex)
    {
        ItemSlot slot = player.inventory[inventoryIndex];

        // -- Only activate if enough charges left and not unlocked already
        if ((decreaseAmount == 0 || slot.amount >= decreaseAmount) && !player.UCE_HasUnlockedClass(playerClass))
        {
            // always call base function too
            base.Use(player, inventoryIndex);

            // -- Decrease Amount
            if (decreaseAmount != 0)
            {
                slot.DecreaseAmount(decreaseAmount);
                player.inventory[inventoryIndex] = slot;
            }

            // -- Unlock the Class
            player.UCE_UnlockClass(playerClass, unlockPopupMessage, unlockPopupIconID, unlockPopupSoundID);
        }
    }

    // -----------------------------------------------------------------------------------
}