// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// ===================================================================================
// LOOT RULES - ENTITY
// ===================================================================================
public partial class Entity
{
    // -----------------------------------------------------------------------------------
    // UCE_ValidateTaggedLootingParty
    // -----------------------------------------------------------------------------------
    public bool UCE_ValidateTaggedLootingParty(Player player)
    {
        if (lastAggressor == null) return true;

        Player plyr;

        if (lastAggressor is Player)
            plyr = (Player)lastAggressor;
        else
            return true;

        bool valid = (
                (
                (plyr.InParty() && plyr.party.Contains(player.name)) ||
                (player.InParty() && player.party.Contains(plyr.name))
                )
                );

        return valid;
    }

    // -----------------------------------------------------------------------------------
    // UCE_ValidateTaggedLootingGuild
    // -----------------------------------------------------------------------------------
    public bool UCE_ValidateTaggedLootingGuild(Player player)
    {
        if (lastAggressor == null) return true;

        Player plyr;

        if (lastAggressor is Player)
            plyr = (Player)lastAggressor;
        else
            return true;

        return (
                plyr.InGuild() &&
                player.InGuild() &&
                 plyr.guild.name != "" &&
                player.guild.name != "" &&
                plyr.guild.name == player.guild.name);
    }

    // -----------------------------------------------------------------------------------
    // UCE_ValidateTaggedLootingRealm
    // -----------------------------------------------------------------------------------
#if _CSPVPREALMS

    public bool UCE_ValidateTaggedLootingRealm(Player player)
    {
        return UCE_getAlliedRealms(player);
    }

#endif

    // -----------------------------------------------------------------------------------
}