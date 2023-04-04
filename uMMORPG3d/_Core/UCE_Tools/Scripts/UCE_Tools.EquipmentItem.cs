// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// EQUIPMENT ITEM

public partial class EquipmentItem
{
    // -----------------------------------------------------------------------------------
    // CanUnequip (Swapping)
    // -----------------------------------------------------------------------------------
    public bool CanUnequip(Player player, int inventoryIndex, int equipmentIndex)
    {
        MutableWrapper<bool> bValid = new MutableWrapper<bool>(true);
        //this.InvokeInstanceDevExtMethods("CanUnequip", player, inventoryIndex, equipmentIndex, bValid);
        Utils.InvokeMany(typeof(EquipmentItem), this, "CanUnequip_", player, inventoryIndex, equipmentIndex, bValid);
        return bValid.Value;
    }

    // -----------------------------------------------------------------------------------
    // CanUnequipClick (Clicking)
    // -----------------------------------------------------------------------------------
    public bool CanUnequipClick(Player player, EquipmentItem item)
    {
        MutableWrapper<bool> bValid = new MutableWrapper<bool>(true);
        //this.InvokeInstanceDevExtMethods("CanUnequipClick", player, item, bValid);
        Utils.InvokeMany(typeof(EquipmentItem), this, "CanUnequipClick_", player, item, bValid);
        return bValid.Value;
    }

    // -----------------------------------------------------------------------------------
}