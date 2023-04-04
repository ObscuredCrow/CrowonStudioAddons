// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// ACCOUNT UNLOCKABLE ITEM

[CreateAssetMenu(menuName = "UCE/Item/Account Unlockable", order = 0)]
public class UCE_Item_AccountUnlockable : UsableItem
{
    [Header("-=-=-=- Account Unlockable Item -=-=-=-")]
    public string unlockableName;

    [Tooltip("Decrease amount by how many each use (can be 0)?")]
    public int decreaseAmount = 1;

    public string unlockPopupMessage = "You unlocked: ";
    public byte unlockPopupIconID = 0;
    public byte unlockPopupSoundID = 0;

    // -----------------------------------------------------------------------------------
    // Use
    // -----------------------------------------------------------------------------------
    public override void Use(Player player, int inventoryIndex)
    {
        ItemSlot slot = player.inventory[inventoryIndex];

        // -- Only activate if enough charges left and not unlocked already
        if ((decreaseAmount == 0 || slot.amount >= decreaseAmount) && !player.UCE_HasAccountUnlock(unlockableName))
        {
            // always call base function too
            base.Use(player, inventoryIndex);

            // -- Decrease Amount
            if (decreaseAmount != 0)
            {
                slot.DecreaseAmount(decreaseAmount);
                player.inventory[inventoryIndex] = slot;
            }

            // -- Unlock the Unlockable
            player.UCE_AccountUnlock(unlockableName, unlockPopupMessage, unlockPopupIconID, unlockPopupSoundID);
        }
    }

    // -----------------------------------------------------------------------------------
}