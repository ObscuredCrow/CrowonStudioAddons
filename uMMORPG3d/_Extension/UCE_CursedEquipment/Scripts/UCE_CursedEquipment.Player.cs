// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;

// PLAYER

public partial class Player
{
    // -----------------------------------------------------------------------------------
    // CmdSwapEquipInventory
    // -----------------------------------------------------------------------------------
    [Command]
    public void CmdSwapEquipInventory(int equipmentIndex, int inventoryIndex)
    {
        // validate: make sure that the slots actually exist in the inventory
        // and in the equipment
        if (isAlive &&
            0 <= inventoryIndex && inventoryIndex < inventory.Count &&
            0 <= equipmentIndex && equipmentIndex < equipment.Count)
        {
            // equipment slot has to be empty (unequip) or un-equipable
            ItemSlot slot = equipment[equipmentIndex];

            if (slot.amount == 0 ||
                slot.item.data is EquipmentItem &&
                ((EquipmentItem)slot.item.data).CanUnequip(this, inventoryIndex, equipmentIndex))
            {
                // swap them
                ItemSlot temp = inventory[inventoryIndex];
                inventory[inventoryIndex] = slot;
                equipment[equipmentIndex] = temp;
            }
        }
    }

    // -----------------------------------------------------------------------------------
    // OnDragAndDrop_EquipmentSlot_InventorySlot
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnDragAndDrop")]
    private void OnDragAndDrop_EquipmentSlot_InventorySlot(int[] slotIndices)
    {
        // merge? check Equals because name AND dynamic variables matter (petLevel etc.)
        // => merge is important when dragging more arrows into an arrow slot!
        if (equipment[slotIndices[0]].amount > 0 && inventory[slotIndices[1]].amount > 0 &&
            equipment[slotIndices[0]].item.Equals(inventory[slotIndices[1]].item))
        {
            CmdMergeEquipInventory(slotIndices[0], slotIndices[1]);
        }
        // swap?
        else
        {
            CmdSwapInventoryEquip(slotIndices[1], slotIndices[0]); // reversed
        }
    }

    // -----------------------------------------------------------------------------------
}