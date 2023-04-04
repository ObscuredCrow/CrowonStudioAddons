// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using System.Collections.Generic;
using UnityEngine;

// SKILL TARGETTED AOE

[CreateAssetMenu(menuName = "UCE/Skill/Aura Taunt", order = 0)]
public class UCE_SkillAuraTaunt : DamageSkill
{
    [Header("-=-=-=- UCE Aura Taunt -=-=-=-")]
    public OneTimeTargetSkillEffect effect;

    public LinearFloat castRadius;
    public LinearFloat successChance;

    [Header("-=-=-=- Apply Buff on Target? -=-=-=-")]
    public BuffSkill applyBuff;

    public LinearInt buffLevel;
    public LinearFloat buffChance;

    [Header("-=-=-=- Targeting -=-=-=-")]
    [Tooltip("[Optional] Changes 'affect' affect into 'not affect' and vice-versa")]
    public bool reverseTargeting;

    [Tooltip("[Optional] Does affect the caster")]
    public bool affectSelf;

    [Tooltip("[Optional] Does affect members of the own party")]
    public bool affectOwnParty;

    [Tooltip("[Optional] Does affect members of the own guild")]
    public bool affectOwnGuild;

    [Tooltip("[Optional] Does affect members of the own realm (requires UCE PVP ZONE AddOn")]
    public bool affectOwnRealm;

    // -----------------------------------------------------------------------------------
    // SpawnEffect
    // -----------------------------------------------------------------------------------
    public void SpawnEffect(Entity caster, Entity spawnTarget)
    {
        if (effect != null)
        {
            GameObject go = Instantiate(effect.gameObject, spawnTarget.transform.position, Quaternion.identity);
            go.GetComponent<OneTimeTargetSkillEffect>().caster = caster;
            go.GetComponent<OneTimeTargetSkillEffect>().target = spawnTarget;
            NetworkServer.Spawn(go);
        }
    }

    // -----------------------------------------------------------------------------------
    // CheckTarget
    // -----------------------------------------------------------------------------------
    public override bool CheckTarget(Entity caster)
    {
        return true;
    }

    // -----------------------------------------------------------------------------------
    // CheckDistance
    // -----------------------------------------------------------------------------------
    public override bool CheckDistance(Entity caster, int skillLevel, out Vector3 destination)
    {
        destination = caster.transform.position;
        return true;
    }

    // -----------------------------------------------------------------------------------
    // Apply
    // -----------------------------------------------------------------------------------
    public override void Apply(Entity caster, int skillLevel)
    {
        List<Entity> targets = new List<Entity>();

        if (caster is Player)
            targets = ((Player)caster).UCE_GetCorrectedTargetsInSphere(caster.transform, castRadius.Get(skillLevel), false, affectSelf, affectOwnParty, affectOwnGuild, affectOwnRealm, reverseTargeting, false, true, true);
        else
            targets = caster.UCE_GetCorrectedTargetsInSphere(caster.transform, castRadius.Get(skillLevel), false, affectSelf, affectOwnParty, affectOwnGuild, affectOwnRealm, reverseTargeting, false, true, true);

        foreach (Entity target in targets)
        {
            if (UnityEngine.Random.value <= successChance.Get(skillLevel))
            {
                target.UCE_OnAggro(caster, 1);
                target.UCE_ApplyBuff(applyBuff, buffLevel.Get(skillLevel), buffChance.Get(skillLevel));
                SpawnEffect(caster, target);
            }
        }

        targets.Clear();
    }
}