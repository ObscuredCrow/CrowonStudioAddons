// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// PLAYER

public partial class Monster
{
    [Header("-=-=-=- UCE FACTION -=-=-=-")]
    public UCE_Tmpl_Faction myFaction;

    // -----------------------------------------------------------------------------------
    // UCE_checkFactionThreshold
    // -----------------------------------------------------------------------------------
    public bool UCE_checkFactionThreshold(Entity entity)
    {
#if _CSPVPREALMS
        if (
            entity is Player &&
            myFaction != null &&
            ((Player)entity).UCE_GetFactionRating(myFaction) <= myFaction.aggressiveThreshold)
        {
            return false;
        }
#endif
        return true;
    }

    // -----------------------------------------------------------------------------------
}