// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Linq;
using UnityEngine;

// EQUIPMENT ITEM

public partial class EquipmentItem
{
    [Header("-=-=- UCE ELEMENTAL ATTACK -=-=-")]
    public UCE_ElementTemplate elementalAttack;

    [Header("-=-=- UCE ELEMENTAL RESISTANCES -=-=-")]
    public UCE_ElementModifier[] elementalResistances;

    public float GetResistance(UCE_ElementTemplate element)
    {
        if (elementalResistances.Any(x => x.template == element))
            return elementalResistances.FirstOrDefault(x => x.template == element).value;
        else
            return 0;
    }

    // -----------------------------------------------------------------------------------
}