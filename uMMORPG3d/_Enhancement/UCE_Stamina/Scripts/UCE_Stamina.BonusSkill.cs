// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Text;
using UnityEngine;
using Mirror;

// BONUS SKILL

public abstract partial class BonusSkill : ScriptableSkill
{
    public bool blockStaminaRecovery;
    public LinearInt bonusStaminaMax;
    public LinearFloat bonusStaminaPercentPerSecond;
}