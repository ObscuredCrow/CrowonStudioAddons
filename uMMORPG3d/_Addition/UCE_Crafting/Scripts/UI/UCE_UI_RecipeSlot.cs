// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Text;
using UnityEngine;
using UnityEngine.UI;

#if _CSCRAFTING

// ===================================================================================
// CRAFTING SLOT
// ===================================================================================
public class UCE_UI_RecipeSlot : MonoBehaviour
{
    public Text nameText;
    public Image image;
    public UIShowToolTip tooltip;

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show(string recipeName)
    {
        UCE_Tmpl_Recipe recipe;

        UCE_Tmpl_Recipe.dict.TryGetValue(recipeName.GetDeterministicHashCode(), out recipe);

        nameText.text = recipe.name;
        image.sprite = recipe.image;
        tooltip.enabled = true;
        tooltip.text = recipe.ToolTip();
    }

    // -----------------------------------------------------------------------------------
    // ToolTip
    // -----------------------------------------------------------------------------------
    public string ToolTip(UCE_Tmpl_Recipe tpl)
    {
        StringBuilder tip = new StringBuilder();

        tip.Append(tpl.name + "\n");
        tip.Append(tpl.toolTip + "\n");

        return tip.ToString();
    }

    // -----------------------------------------------------------------------------------
}

#endif