// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

#if _CSCRAFTING

// CRAFTING BUTTON

public partial class UCE_UI_CraftingButton : MonoBehaviour
{
    public GameObject panel;
    public Text text;

    protected string category;

    // -----------------------------------------------------------------------------------
    // SetCategory
    // -----------------------------------------------------------------------------------
    public void SetCategory(string _category)
    {
        category = _category;
        text.text = _category;
    }

    // -----------------------------------------------------------------------------------
    // OnClick
    // -----------------------------------------------------------------------------------
    public void OnClick()
    {
        UCE_UI_Crafting co = panel.GetComponent<UCE_UI_Crafting>();

        if (co)
        {
            co.changeCategory(category);
        }
    }

    // -----------------------------------------------------------------------------------
}

#endif