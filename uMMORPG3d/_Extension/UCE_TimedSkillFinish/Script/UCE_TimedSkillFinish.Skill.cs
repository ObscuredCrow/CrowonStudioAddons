// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;

// SKILL

public partial struct Skill
{
    // -----------------------------------------------------------------------------------
    // UCE_CastTimePassed
    // -----------------------------------------------------------------------------------
    public double UCE_CastTimePassed() => (NetworkTime.time - castTimeEnd) + castTime;
}