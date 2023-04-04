// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// MONSTER
public partial class Monster
{
    // ================================= MISC FUNCS ======================================
    // A bunch of very common utility functions that are missing on the core asset
    // ===================================================================================

    // -----------------------------------------------------------------------------------
    // UCE_CanAttack
    // Replaces the built-in CanAttack check. This one can be expanded, the built-in one not.
    // -----------------------------------------------------------------------------------
    public override bool UCE_CanAttack(Entity entity)
    {
        return
            base.UCE_CanAttack(entity)
#if _CSPVPREALMS
            && UCE_getAttackAllowance(entity)
#endif
            ;
    }

    // -----------------------------------------------------------------------------------
}