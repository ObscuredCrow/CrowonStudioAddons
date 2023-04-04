// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;
using System.Collections.Generic;
using UnityEditor;
using System;

// ENTITY

public partial class Entity
{
    [Header("BLUEPRINTS (Editor)")]
    public UCE_TemplateEntityBlueprint[] blueprints;

    // -----------------------------------------------------------------------------------
    // ApplyBlueprints
    // @Editor
    // -----------------------------------------------------------------------------------
    public void ApplyBlueprints()
    {
#if UNITY_EDITOR

        int baseValue = 0;
        int bonusPerLevel = 0;

        // -------- Health
        foreach (UCE_TemplateEntityBlueprint blueprint in blueprints)
        {
            if (!blueprint) continue;

            baseValue += blueprint.healthMax.baseValue;
            bonusPerLevel += blueprint.healthMax.bonusPerLevel;
        }

        if (baseValue != 0)
            _healthMax = new LinearInt { baseValue = baseValue, bonusPerLevel = bonusPerLevel };

        // --------

        // --------

        // --------

#endif
    }

    // -----------------------------------------------------------------------------------
}