// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Text;
using UnityEngine;
using Mirror;

// PLAYER WAREHOUSE - ITEM

[CreateAssetMenu(menuName = "UCE/Item/Warehouse", order = 0)]
public class UCE_Tmpl_ItemPlayerWarehouse : UsableItem
{
    [Header("[-=-=-=- Warehouse Item -=-=-=-]")]
    [Tooltip("Decrease amount by how many each use (can be 0)?")]
    public int decreaseAmount = 1;

    // -----------------------------------------------------------------------------------
    // Use
    // @Server
    // -----------------------------------------------------------------------------------
    public override void Use(Player player, int inventoryIndex)
    {
        ItemSlot slot = player.inventory[inventoryIndex];

        // -- Only activate if enough charges left
        if (decreaseAmount == 0 || slot.amount >= decreaseAmount)
        {
            // always call base function too
            base.Use(player, inventoryIndex);

            // -- Decrease Amount
            if (decreaseAmount != 0)
            {
                slot.DecreaseAmount(decreaseAmount);
                player.inventory[inventoryIndex] = slot;
            }
        }
    }

    // -----------------------------------------------------------------------------------
    // OnUsed
    // @Client
    // -----------------------------------------------------------------------------------
    public override void OnUsed(Player player)
    {
        UCE_UI_PlayerWarehouse.singleton.Show();
    }

    // -----------------------------------------------------------------------------------
}