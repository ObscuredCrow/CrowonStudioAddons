// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;
using System;
using System.Linq;
using System.Collections;

// =======================================================================================
// MONSTER
// =======================================================================================
public partial class Monster
{
    // -----------------------------------------------------------------------------------
    // OnDamageDealt_UCE_Morale
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnDamageDealt")]
    private void OnDamageDealt_UCE_Morale(int amount)
    {
        morale -= amount;
    }

    // -----------------------------------------------------------------------------------
}

// =======================================================================================