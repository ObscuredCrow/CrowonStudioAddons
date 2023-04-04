// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// TemplateEntityBlueprint

[CreateAssetMenu(menuName = "UCE/Other/Entity Blueprint", fileName = "New UCE Entity Blueprint", order = 0)]
public partial class UCE_TemplateEntityBlueprint : ScriptableObject
{
    [Header("Health")]
    public LinearInt healthMax = new LinearInt { baseValue = 100, bonusPerLevel = 0 };

    /*
     * TODO: add all other stats
     * like mana, crit rate, etc.
     * */

    // -----------------------------------------------------------------------------------
    // OnValidate
    // -----------------------------------------------------------------------------------
    public void OnValidate()
    {
#if UNITY_EDITOR

#endif
    }

    // -----------------------------------------------------------------------------------
}