// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;

// UCE_HonorShopCategory

[Serializable]
public partial struct UCE_HonorShopCategory
{
    public string categoryName;
    public UCE_Tmpl_HonorCurrency honorCurrency;
    public ScriptableItem[] items;
}