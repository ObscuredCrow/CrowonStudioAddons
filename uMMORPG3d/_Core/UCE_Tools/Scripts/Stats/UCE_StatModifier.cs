// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE STAT MODIFIER

[System.Serializable]
public class UCE_StatModifier
{
#if _CSATTRIBUTES
    [Header("[-=-=- UCE ATTRIBUTE MODIFIERS -=-=-]")]
    public UCE_AttributeModifier[] UCE_AttributeModifiers = { };
#endif
#if _CSELEMENTS
    [Header("[-=-=- UCE ELEMENTAL RESISTANCES -=-=-]")]
    public UCE_ElementModifier[] elementalResistances;
#endif

    [Header("[-=-=- UCE MAIN STAT MODIFIERS -=-=-]")]
    public int healthBonus;

    public int manaBonus;
#if _CSSTAMINA
    public int staminaBonus;
#endif
    public int damageBonus;
    public int defenseBonus;

    [Header("[-=-=- UCE SECONDARY STAT MODIFIERS -=-=-]")]
    public float blockChanceBonus;

    public float criticalChanceBonus;
#if _CSATTRIBUTES
    public float bonusBlockFactor;
    public float bonusCriticalFactor;
    public float bonusDrainHealthFactor;
    public float bonusDrainManaFactor;
    public float bonusReflectDamageFactor;
    public float bonusDefenseBreakFactor;
    public float bonusBlockBreakFactor;
    public float bonusCriticalEvasion;
    public float bonusAccuracy;
    public float bonusResistance;
    public float bonusAbsorbHealthFactor;
    public float bonusAbsorbManaFactor;
#endif

    // -----------------------------------------------------------------------------------
    // hasModifier
    // -----------------------------------------------------------------------------------
    public bool hasModifier
    {
        get
        {
            return
                    (
#if _CSATTRIBUTES
                    (UCE_AttributeModifiers != null && UCE_AttributeModifiers.Length > 0) ||
#endif
#if _CSELEMENTS
                    (elementalResistances != null && elementalResistances.Length > 0) ||
#endif
#if _CSATTRIBUTES
                    bonusBlockFactor != 0 ||
                    bonusCriticalFactor != 0 ||
                    bonusDrainHealthFactor != 0 ||
                    bonusDrainManaFactor != 0 ||
                    bonusReflectDamageFactor != 0 ||
                    bonusDefenseBreakFactor != 0 ||
                    bonusBlockBreakFactor != 0 ||
                    bonusCriticalEvasion != 0 ||
                    bonusAccuracy != 0 ||
                    bonusResistance != 0 ||
                    bonusAbsorbHealthFactor != 0 ||
                    bonusAbsorbManaFactor != 0 ||
#endif
                    healthBonus != 0 ||
                    manaBonus != 0 ||
#if _CSSTAMINA
                    staminaBonus != 0 ||
#endif
                    damageBonus != 0 ||
                    defenseBonus != 0 ||
                    blockChanceBonus != 0 ||
                    criticalChanceBonus != 0
                    );
        }
    }

    // -----------------------------------------------------------------------------------
}