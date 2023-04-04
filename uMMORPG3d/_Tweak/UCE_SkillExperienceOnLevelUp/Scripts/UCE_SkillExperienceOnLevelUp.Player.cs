// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// PLAYER

public partial class Player
{
    [Header("-=-=-=- UCE SKILL EXP ON LEVEL UP -=-=-=-")]
    public LinearInt skillExpOnLevelUp;
    public bool traditional = true;

    // -----------------------------------------------------------------------------------
    // OnLevelUp_UCE_LevelUpNotice
    // -----------------------------------------------------------------------------------
    [Server]
    [DevExtMethods("OnLevelUp")]
    private void OnLevelUp_UCE_SkillExperienceOnLevelUp()
    {
        if (traditional) skillExperience += skillExpOnLevelUp.Get(level);
        else skillExperience += skillExpOnLevelUp.bonusPerLevel + skillExpOnLevelUp.baseValue;
    }
}