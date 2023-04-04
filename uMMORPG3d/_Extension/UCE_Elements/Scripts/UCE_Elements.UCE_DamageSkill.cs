// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

#if _CSPROJECTILES || _CSMELEE

public abstract partial class UCE_DamageSkill : ScriptableSkill
{
    [Header("-=-=- UCE ELEMENTAL ATTACK -=-=-")]
    public UCE_ElementTemplate element;
}

#endif