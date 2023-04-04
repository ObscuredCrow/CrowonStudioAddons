// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;
using System.Linq;
using UnityEngine;

// ENTITY

public partial class Entity
{
    // -----------------------------------------------------------------------------------
    // gold
    // -----------------------------------------------------------------------------------
    public long gold
    {
        get { return _gold; }
        set
        {
#if _CSBUFFGOLD
            float fGoldFactor = buffs.Sum(x => x.boostGold);
            if (fGoldFactor != 0 && value > _gold)
            {
                long diff = Math.Max(value, _gold) - Math.Min(value, _gold);
                float goldGain = (diff * fGoldFactor) + diff;
                _gold = _gold + (long)Mathf.Round(goldGain);
            }
            else
            {
                _gold = Math.Max(value, 0);
            }
#else
            _gold = Math.Max(value, 0);
#endif
        }
    }

    // -----------------------------------------------------------------------------------
}