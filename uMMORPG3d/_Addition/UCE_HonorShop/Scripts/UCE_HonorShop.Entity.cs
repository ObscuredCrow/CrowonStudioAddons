// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE HONOR SHOP ENTITY

public partial class Entity
{
    protected const string MSG_GAINED = "Gained ";

    [Header("-=-=-=- Honor Rewards -=-=-=-")]
    public UCE_HonorShopCurrencyDrop[] currencyDrops;

    // -----------------------------------------------------------------------------------
    // OnDeath_UCE_HonorShop
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnDeath")]
    private void OnDeath_UCE_HonorShop()
    {
        if (lastAggressor != null && lastAggressor is Player)
        {
            Player player = (Player)lastAggressor;

            long amount = 0;
            bool assigned = false;

            foreach (UCE_HonorShopCurrencyDrop currencyDrop in currencyDrops)
            {
                if (currencyDrop.honorCurrency != null && currencyDrop.honorCurrency.dropRequirements.CheckRequirements(player))
                {
#if _CSPVPREALMS
                    if (currencyDrop.honorCurrency.FromHostileRealmsOnly && UCE_getAlliedRealms(player))
                        return;
#endif
                    amount = currencyDrop.amount;
                    assigned = false;

                    if (currencyDrop.honorCurrency.perLevel)
                        amount *= level;

                    // -- share to party
                    if (player.InParty() && currencyDrop.honorCurrency.shareWithParty)
                    {
                        player.UCE_HonorCurrency_ShareToParty(currencyDrop.honorCurrency, amount);
                        assigned = true;
                    }

                    // -- share to guild
                    if (player.InGuild() && currencyDrop.honorCurrency.shareWithGuild)
                    {
                        player.UCE_HonorCurrency_ShareToGuild(currencyDrop.honorCurrency, amount);
                        assigned = true;
                    }

#if _CSPVPREALMS
                    // -- share to realm
                    if (currencyDrop.honorCurrency.shareWithRealm)
                    {
                        player.UCE_HonorCurrency_ShareToRealm(currencyDrop.honorCurrency, amount);
                        assigned = true;
                    }
#endif

                    // -- if we came this far, we add it to the player directly
                    if (!assigned)
                    {
                        player.UCE_AddHonorCurrency(currencyDrop.honorCurrency, amount);
                        player.UCE_TargetAddMessage(MSG_GAINED + currencyDrop.honorCurrency.name + " x" + amount.ToString());
                    }
                }
            }
        }
    }

    // -----------------------------------------------------------------------------------
}