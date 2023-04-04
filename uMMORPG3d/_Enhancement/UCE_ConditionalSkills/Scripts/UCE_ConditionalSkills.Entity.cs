// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;

// ENTITY

public partial class Entity
{
    protected int lastSkill = -1;

    // -------------------------------------------------------------------------
    // NextSkill
    // -------------------------------------------------------------------------
    protected int NextSkill()
    {
        for (int i = 0; i < skills.Count; ++i)
        {
            int index = (lastSkill + 1 + i) % skills.Count;
            if (skills[index].UCE_CheckSkillConditions(this))
                return index;
        }
        return -1;
    }
}