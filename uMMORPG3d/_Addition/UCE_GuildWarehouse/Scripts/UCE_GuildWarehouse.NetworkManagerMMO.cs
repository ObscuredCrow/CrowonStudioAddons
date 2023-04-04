// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;

// NETWORK MANAGER

public partial class NetworkManagerMMO
{
    // -----------------------------------------------------------------------------------
    // OnServerDisconnect
    // @Server
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnServerDiconnect")]
    private void OnServerDisconnect_UCE_GuildUCE_warehouse(NetworkConnection conn)
    {
        if (conn.identity != null)
            Database.singleton.UCE_SaveGuildWarehouse(conn.identity.GetComponent<Player>());
    }

    // -----------------------------------------------------------------------------------
}