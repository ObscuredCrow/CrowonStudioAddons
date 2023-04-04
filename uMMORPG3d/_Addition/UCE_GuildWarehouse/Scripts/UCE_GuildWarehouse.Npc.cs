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
    [Header("[-=-=-=- UCE GUILD WAREHOUSE -=-=-=-]")]
    public bool offersGuildWarehouse = false;

    public bool accessViceOrMasterOnly;
    [HideInInspector] public SyncListString guildWarehouseBusy = new SyncListString();

    // -----------------------------------------------------------------------------------
    // checkWarehouseAccess
    // -----------------------------------------------------------------------------------
    public bool checkWarehouseAccess(Player player)
    {
        if (!offersGuildWarehouse || !player.InGuild()) return false;
        if (!accessViceOrMasterOnly) return true;

        return player.guild.CanNotify(player.name);
    }

    // -----------------------------------------------------------------------------------
}