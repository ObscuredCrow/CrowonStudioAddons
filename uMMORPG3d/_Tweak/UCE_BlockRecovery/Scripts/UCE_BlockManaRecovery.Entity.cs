// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using System.Linq;

// ENTITY

public partial class Entity
{
    public bool _manaRecovery = true; // can be disabled in combat etc.

    // -----------------------------------------------------------------------------------
    // manaRecovery
    // -----------------------------------------------------------------------------------
    public virtual bool manaRecovery
    {
        get
        {
#if _CSBLOCKRECOVERY
            return manaRecoveryRate < 0 || (_manaRecovery && !buffs.Any(x => x.blockManaRecovery));
#else
			return _manaRecovery;
#endif
        }
    }

    // -----------------------------------------------------------------------------------
}
