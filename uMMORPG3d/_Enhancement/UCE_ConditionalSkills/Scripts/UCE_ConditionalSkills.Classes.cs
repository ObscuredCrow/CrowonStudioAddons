// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE CONDITIONAL SKILL - CLASS

[System.Serializable]
public partial class UCE_ConditionalSkill
{
    [Header("Random")]
    [Tooltip("Basic, random activation chance of this skill (0.1 = 10%)")]
    [Range(0, 1)] public float activationChance = 0f;

    [Header("Health")]
    [Tooltip("Health of the caster must be 'below' or 'above' the threshold")]
    public Monster.ParentThreshold healthThreshold = Monster.ParentThreshold.None;

    [Tooltip("Health treshold of the caster in order to trigger condition")]
    [Range(0, 1)] public float casterHealth = 0;

#if _CSMORALE

    [Header("Morale")]
    [Tooltip("Morale of the caster must be 'below' or 'above' the threshold")]
    public Monster.ParentThreshold moraleThreshold = Monster.ParentThreshold.None;

    [Tooltip("Morale treshold of the caster in order to trigger condition")]
    [Range(0, 1)] public float casterMorale = 0;

#endif

    [Header("Other")]
    [Tooltip("Caster must have this active Buff in order to trigger condition")]
    public BuffSkill activeBuff;
}