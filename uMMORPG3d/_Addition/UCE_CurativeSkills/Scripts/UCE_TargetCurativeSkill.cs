// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections.Generic;
using UnityEngine;

// TARGET CURATIVE SKILL

[CreateAssetMenu(menuName = "UCE/Skill/Target Curative", order = 0)]
public class UCE_TargetCurativeSkill : UCE_CurativeSkill
{
    // -----------------------------------------------------------------------------------
    // Apply
    // -----------------------------------------------------------------------------------
    public override void Apply(Entity caster, int skillLevel)
    {
        List<Entity> targets = new List<Entity>();

        if (SpawnEffectOnMainTargetOnly)
            SpawnEffect(caster, caster.target);

        if (
            (caster is Player && caster.target is Player && ((Player)caster).UCE_SameCheck((Player)caster.target, affectSelf, affectPlayers, affectOwnParty, affectOwnGuild, affectOwnRealm, reverseTargeting)) ||
            (caster.target is Monster && affectEnemies) ||
            (caster.target == caster && affectSelf)
            )
        {
            if (reviveChance.Get(skillLevel) > 0 && !caster.target.isAlive)
                targets.Add(caster.target);
            else if (reviveChance.Get(skillLevel) <= 0 && caster.target.isAlive)
                targets.Add(caster.target);
        }

        if (castRadius.Get(skillLevel) > 0)
        {
            if (caster is Player)
                targets.AddRange(((Player)caster).UCE_GetCorrectedTargetsInSphere(caster.target.transform, castRadius.Get(skillLevel), reviveChance.Get(skillLevel) > 0, affectSelf, affectOwnParty, affectOwnGuild, affectOwnRealm, reverseTargeting, affectPlayers, affectEnemies));
            else
                targets.AddRange(caster.UCE_GetCorrectedTargetsInSphere(caster.target.transform, castRadius.Get(skillLevel), reviveChance.Get(skillLevel) > 0, affectSelf, affectOwnParty, affectOwnGuild, affectOwnRealm, reverseTargeting, affectPlayers, affectEnemies));
        }

        ApplyToTargets(targets, caster, skillLevel);

        targets.Clear();
    }

    // -----------------------------------------------------------------------------------
}