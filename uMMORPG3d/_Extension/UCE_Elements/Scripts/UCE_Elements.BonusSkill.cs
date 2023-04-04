// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Linq;
using UnityEngine;

public abstract partial class BonusSkill : ScriptableSkill
{
    [Header("-=-=- UCE ELEMENTAL RESISTANCES -=-=-")]
    public LevelBasedElement[] elementalResistances;

    // GetResistance

    public float GetResistance(UCE_ElementTemplate element, int level)
    {
        return elementalResistances.FirstOrDefault(x => x.template == element).Get(level);
    }
}