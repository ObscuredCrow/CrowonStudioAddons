// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// GUILD WAREHOUSE - NPC

public partial class Npc
{
    [Header("[-=-=-=- UCE GUILD UPGRADES -=-=-=-]")]
    public bool offersGuildUpgrade = false;

    // -----------------------------------------------------------------------------------
    // checkGuildUpgradeAccess
    // -----------------------------------------------------------------------------------
    public bool checkGuildUpgradeAccess(Player player)
    {
        if (!offersGuildUpgrade || !player.InGuild()) return false;

        return player.guild.CanNotify(player.name);
    }

    // -----------------------------------------------------------------------------------
}