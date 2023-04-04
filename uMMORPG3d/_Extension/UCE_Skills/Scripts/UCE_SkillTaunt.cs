// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// TAUNT SKILL

[CreateAssetMenu(menuName = "UCE/Skill/Taunt", order = 0)]
public class UCE_SkillTaunt : ScriptableSkill
{
    [Header("-=-=-=- UCE Taunt Skill -=-=-=-")]
    public LinearFloat successChance;

    public string tauntMessage = "You taunted: ";
    public string failedMessage = "You failed to taunt: ";

    // -----------------------------------------------------------------------------------
    // CheckTarget
    // -----------------------------------------------------------------------------------
    public override bool CheckTarget(Entity caster)
    {
        return caster.target != null && caster.CanAttack(caster.target);
    }

    // -----------------------------------------------------------------------------------
    // CheckDistance
    // -----------------------------------------------------------------------------------
    public override bool CheckDistance(Entity caster, int skillLevel, out Vector3 destination)
    {
        if (caster.target != null)
        {
            destination = caster.target.collider.ClosestPointOnBounds(caster.transform.position);
            return Utils.ClosestDistance(caster, caster.target) <= castRange.Get(skillLevel);
        }
        destination = caster.transform.position;
        return false;
    }

    // -----------------------------------------------------------------------------------
    // Apply
    // -----------------------------------------------------------------------------------
    public override void Apply(Entity caster, int skillLevel)
    {
        Player player = (Player)caster;

        if (player.target != null && player.target is Monster)
        {
            Monster monster = player.target.GetComponent<Monster>();

            if (UnityEngine.Random.value <= successChance.Get(skillLevel))
            {
                monster.UCE_OnAggro(player, 1);
                player.UCE_TargetAddMessage(tauntMessage + monster.name);
            }
            else
            {
                player.UCE_TargetAddMessage(failedMessage + monster.name);
            }
        }
    }

    // -----------------------------------------------------------------------------------
}