// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;

// UCE_HonorShopCurrencyDrop

[Serializable]
public partial struct UCE_HonorShopCurrencyDrop
{
    public UCE_Tmpl_HonorCurrency honorCurrency;
    public long amountMin;
    public long amountMax;

    public long amount
    {
        get
        {
            return (long)UnityEngine.Random.Range(amountMin, amountMax);
        }
    }
}