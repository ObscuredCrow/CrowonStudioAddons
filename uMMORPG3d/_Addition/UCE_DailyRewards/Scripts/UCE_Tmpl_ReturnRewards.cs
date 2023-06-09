// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// RETURN REWARDS - TEMPLATE

[CreateAssetMenu(fileName = "UCE_Tmpl_ReturnRewards", menuName = "UCE/Template/Return Rewards", order = 0)]
public class UCE_Tmpl_ReturnRewards : ScriptableObject
{
    [Header("-=-=-=- Returning Player Reward -=-=-=-")]
    [Tooltip("One click deactivation")]
    public bool isActive = true;

    [Tooltip("Min player level to enable the reward")]
    public int MinLevel = 1;

    [Tooltip("This quest must be completed first")]
#if _CSQUESTS
    public UCE_ScriptableQuest requiredQuest;

#else
    public ScriptableQuest requiredQuest;

#endif

    [Tooltip("Days between login to activate reward counter")]
    public int LoginIntervalDays = 30;

    [Tooltip("Define your rewards by adding and editing entries")]
    public UCE_DailyReward reward;
}