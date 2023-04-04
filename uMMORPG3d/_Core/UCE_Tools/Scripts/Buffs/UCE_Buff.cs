// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// BUFF

public partial struct Buff
{
    public bool cannotRemove { get { return data.cannotRemove; } }
    public bool blockNerfs { get { return data.blockNerfs; } }
    public bool blockBuffs { get { return data.blockBuffs; } }

#if _CSBLOCKRECOVERY
    public bool blockHealthRecovery { get { return data.blockHealthRecovery; } }
#endif
#if _CSBLOCKRECOVERY
    public bool blockManaRecovery { get { return data.blockManaRecovery; } }
#endif
#if _CSBUFFENDURE
    public bool endure { get { return data.endure; } }
#endif
#if _CSBUFFEXPERIENCE
    public float boostExperience { get { return data.boostExperience; } }
#endif
#if _CSBUFFGOLD
    public float boostGold { get { return data.boostGold; } }
#endif
#if _CSBUFFINVINCIBILITY
    public bool invincibility { get { return data.invincibility; } }
#endif

    // -----------------------------------------------------------------------------------
    // CheckBuffType
    // -----------------------------------------------------------------------------------
    public bool CheckBuffType(BuffType buffType)
    {
        if (buffType == BuffType.Both) return true;

        return (
                (buffType == BuffType.Buff && !data.disadvantageous) ||
                (buffType == BuffType.Nerf && data.disadvantageous));
    }

    // -----------------------------------------------------------------------------------
}