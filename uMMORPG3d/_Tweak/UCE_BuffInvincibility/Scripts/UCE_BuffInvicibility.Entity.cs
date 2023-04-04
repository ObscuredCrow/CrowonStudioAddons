// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Linq;

// ENTITY

public partial class Entity
{
    public bool _invincible = false;

    // -----------------------------------------------------------------------------------
    // invincible
    // -----------------------------------------------------------------------------------
    public virtual bool invincible
    {
        get
        {
#if _CSBUFFINVINCIBILITY
            return _invincible || buffs.Any(x => x.invincibility);
#else
            return _invincible;
#endif
        }
    }

    // -----------------------------------------------------------------------------------
}