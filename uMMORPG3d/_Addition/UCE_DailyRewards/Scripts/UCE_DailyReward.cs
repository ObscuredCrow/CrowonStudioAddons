// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// ===================================================================================
// SIMPLE DAILY REWARD
// ===================================================================================
[System.Serializable]
public class UCE_DailyReward
{
    [Header("-=-=- UCE Daily Reward -=-=-")]
    public long rewardGold;

    public long rewardCoins;
    public long rewardExperience;
    public long rewardSkillExperience;

    public UCE_ItemRequirement[] rewardItems;

#if _CSHONORSHOP
    public UCE_HonorShopCurrencyDrop[] honorCurrencies;
#endif
}

// ===================================================================================