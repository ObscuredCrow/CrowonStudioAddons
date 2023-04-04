// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// GUILD UPGRADES CONFIG

[CreateAssetMenu(fileName = "UCE Guild Upgrades", menuName = "UCE/Template/Guild Upgrades", order = 0)]
public class UCE_Tmpl_GuildUpgrades : ScriptableObject
{
    [Header("[CAPACITY]")]
    public LinearInt guildCapacity = new LinearInt { baseValue = 10 };

    [Header("[REWARDS (1 item per level)]")]
    [Tooltip("The player who is upgrading gains the item")]
    public ScriptableItemAndAmount[] rewardItem;

    [Header("[UPRADING]")]
    public UCE_Cost[] guildUpgradeCost;

    [Header("[MESSAGES]")]
    public string guildUpgradeLabel = "Guild upgraded!";
}