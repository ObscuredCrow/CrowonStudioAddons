// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Text;
using UnityEngine;

#if _CSCRAFTING

// RECIPE ITEM

[CreateAssetMenu(fileName = "New UCE Recipe", menuName = "UCE/Item/Recipe", order = 0)]
public class UCE_Item_Recipe : UsableItem
{
    [Header("-=-=-=- Recipe Item -=-=-=-")]
    public UCE_Tmpl_Recipe[] learnedRecipes;

    public bool hasUnlimitedUse;

    public string tooltipHeader = "Learned Recipes:";

    // -----------------------------------------------------------------------------------
    // Use
    // -----------------------------------------------------------------------------------
    public override void Use(Player player, int inventoryIndex)
    {
        ItemSlot slot = player.inventory[inventoryIndex];

        if (player.UCE_Crafting_LearnRecipe(learnedRecipes))
        {
            // always call base function too
            base.Use(player, inventoryIndex);

            //decrease amount on use if has no unlimited amount
            if (hasUnlimitedUse == false)
            {
                slot.DecreaseAmount(1);
                player.inventory[inventoryIndex] = slot;
            }
        }
    }

    // -----------------------------------------------------------------------------------
    // ToolTip
    // -----------------------------------------------------------------------------------
    public override string ToolTip()
    {
        StringBuilder tip = new StringBuilder(base.ToolTip());

        string recipeNames = tooltipHeader;

        foreach (UCE_Tmpl_Recipe recipe in learnedRecipes)
            recipeNames += "* " + recipe.name + "\n";

        tip.Replace("{SIMPLERECIPE}", recipeNames);

        return tip.ToString();
    }

    // -----------------------------------------------------------------------------------
}

#endif