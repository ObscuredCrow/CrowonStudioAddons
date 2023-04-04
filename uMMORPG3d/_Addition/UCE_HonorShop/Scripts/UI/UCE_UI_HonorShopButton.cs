// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE UI HONOR SHOP BUTTON

public partial class UCE_UI_CSHONORSHOPButton : MonoBehaviour
{
    public GameObject honorShopCurrencyPanel;

    // -----------------------------------------------------------------------------------
    // ShowHonorShopCurrencyPanel
    // -----------------------------------------------------------------------------------
    public void ShowHonorShopCurrencyPanel()
    {
        if (honorShopCurrencyPanel.activeInHierarchy)
            honorShopCurrencyPanel.SetActive(false);
        else
            honorShopCurrencyPanel.SetActive(true);
    }

    // -----------------------------------------------------------------------------------
}