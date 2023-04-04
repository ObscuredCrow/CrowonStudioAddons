// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// SKILL STUB

[CreateAssetMenu(menuName = "UCE/Skill/Stub", order = 0)]
public class UCE_SkillStub : ScriptableSkill
{
    public override bool CheckTarget(Entity entity)
    {
        return true;
    }

    public override bool CheckDistance(Entity caster, int skillLevel, out Vector3 destination)
    {
        destination = Vector3.zero;
        return true;
    }

    public override void Apply(Entity caster, int skillLevel)
    {
    }
}