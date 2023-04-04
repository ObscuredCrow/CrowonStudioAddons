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

// SKILL

public partial struct Skill
{
    // -------------------------------------------------------------------------
    // UCE_CheckSkillConditions
    // -------------------------------------------------------------------------
    public bool UCE_CheckSkillConditions(Entity caster)
    {
        if(data.skillConditions.activationChance != 0)
        {
            if (UnityEngine.Random.value < data.skillConditions.activationChance)
            {
                if (data.skillConditions.activeBuff != null)
                {
                    if (caster.UCE_checkHasBuff(data.skillConditions.activeBuff))
                    {
                        return CheckThresholds(caster) && CheckSelf(caster);
                    }
                }
                else return CheckThresholds(caster) && CheckSelf(caster);
            }
        }

        return true;
    }

    private bool CheckThresholds(Entity caster)
    {
        if (data.skillConditions.healthThreshold != Monster.ParentThreshold.None)
        {
            if (data.skillConditions.healthThreshold == Monster.ParentThreshold.Above && (caster.health > caster.healthMax * data.skillConditions.casterHealth))
                return true;

            if (data.skillConditions.healthThreshold == Monster.ParentThreshold.Below && (caster.health < caster.healthMax * data.skillConditions.casterHealth))
                return true;
        }
#if _CSMORALE
        if (data.skillConditions.moraleThreshold != Monster.ParentThreshold.None)
        {
            if (data.skillConditions.moraleThreshold == Monster.ParentThreshold.Above && (caster.morale > caster.moraleMax * data.skillConditions.casterMorale))
                return true;

            if (data.skillConditions.moraleThreshold == Monster.ParentThreshold.Below && (caster.morale < caster.moraleMax * data.skillConditions.casterMorale))
                return true;
        }
#endif
        return false;
    }
}