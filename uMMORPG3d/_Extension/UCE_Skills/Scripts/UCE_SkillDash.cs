﻿// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UCE/Skill/Dash", order = 0)]
public class UCE_SkillDash : ScriptableSkill
{
    [Header("Dash Settings")]
    public LinearFloat distance;

    public LinearFloat timeDash;

    public override void Apply(Entity caster, int skillLevel)
    {
        caster.StartDash(caster.transform.position + (caster.LookDirection * distance.Get(skillLevel)), timeDash.Get(skillLevel));
    }

    public override bool CheckDistance(Entity caster, int skillLevel, out Vector3 destination)
    {
        destination = caster.transform.position;
        return true;
    }

    public override bool CheckTarget(Entity caster)
    {
        return true;
    }
}