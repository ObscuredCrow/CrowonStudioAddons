// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Linq;

// ITEM

public partial struct Item
{
    // -----------------------------------------------------------------------------------
    // UCE_GetHonorCurrency
    // -----------------------------------------------------------------------------------
    public long UCE_GetHonorCurrency(UCE_Tmpl_HonorCurrency honorCurrency)
    {
        return data.currencyCosts.FirstOrDefault(x => x.honorCurrency.name == honorCurrency.name).amount;
    }
}