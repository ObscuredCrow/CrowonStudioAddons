// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Mirror;

// BUFF

public partial struct Buff
{
    public bool blockStaminaRecovery => data.blockStaminaRecovery;
    public int bonusStaminaMax => data.bonusStaminaMax.Get(level);
    public float bonusStaminaPercentPerSecond => data.bonusStaminaPercentPerSecond.Get(level);
}