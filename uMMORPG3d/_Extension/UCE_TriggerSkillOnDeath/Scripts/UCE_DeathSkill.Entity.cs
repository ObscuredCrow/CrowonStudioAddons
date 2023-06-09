// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// ENTITY

public partial class Entity
{
    [Header("[-=-=- UCE DEATH SKILL -=-=-]")]
    public UCE_DeathSkill deathSkill;

    // -----------------------------------------------------------------------------------
    // OnDeath_UCE_DeathSkill
    // ----------------------------------------------------------------------------------
    [DevExtMethods("OnDeath")]
    private void OnDeath_UCE_DeathSkill()
    {
        if (deathSkill.deathSkill.Length == 0 || deathSkill.deathSkillChance <= 0) return;

        if (UnityEngine.Random.value <= deathSkill.deathSkillChance)
        {
            target = this;
            int idx = UnityEngine.Random.Range(0, deathSkill.deathSkill.Length - 1);
            Skill skill = new Skill(deathSkill.deathSkill[idx]);
            skill.level = UnityEngine.Random.Range(deathSkill.deathSkillMinLevel, deathSkill.deathSkillMaxLevel);
            skill.Apply(this);
            target = null;
        }
    }

    // -----------------------------------------------------------------------------------
}