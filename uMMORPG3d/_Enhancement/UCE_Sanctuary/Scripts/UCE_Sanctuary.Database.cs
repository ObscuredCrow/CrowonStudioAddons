// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;

#if _MYSQL && _SERVER
using MySql.Data;
using MySql.Data.MySqlClient;
#elif _SQLITE && _SERVER

using SQLite;

#endif

// DATABASE (SQLite / mySQL Hybrid)

public partial class Database
{
    //private class character_lastonline
    //{
    //    [PrimaryKey] // important for performance: O(log n) instead of O(n)
    //    [Collation("NOCASE")] // [COLLATE NOCASE for case insensitive compare. this way we can't both create 'Archer' and 'archer' as characters]
    //    public string character { get; set; }

    //    [Indexed] // add index on account to avoid full scans when loading characters
    //    public string account { get; set; }

    //    public DateTime lastOnline { get; set; }
    //}

    // -----------------------------------------------------------------------------------
    // Connect_UCE_Sanctuary
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Connect")]
    private void Connect_UCE_Sanctuary() {
#if _MYSQL && _SERVER
		ExecuteNonQueryMySql(@"CREATE TABLE IF NOT EXISTS character_lastonline (
				`character` VARCHAR(32) NOT NULL,
				lastOnline VARCHAR(64) NOT NULL,
                    PRIMARY KEY(`character`)
                ) CHARACTER SET=utf8mb4");
#elif _SQLITE && _SERVER
        connection.CreateTable<character_lastonline>();
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterLoad_UCE_Sanctuary
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterLoad")]
    private void CharacterLoad_UCE_Sanctuary(Player player) {
#if _MYSQL && _SERVER
		var row = (string)ExecuteScalarMySql("SELECT lastOnline FROM character_lastonline WHERE `character`=@name", new MySqlParameter("@name", player.name));
		if (!string.IsNullOrWhiteSpace(row)) {
			DateTime time 				= DateTime.Parse(row);
			player.UCE_SecondsPassed 	= (DateTime.UtcNow - time).TotalSeconds;
		} else {
			player.UCE_SecondsPassed 	= 0;
		}
#elif _SQLITE && _SERVER
        var results = connection.FindWithQuery<character_lastonline>("SELECT lastOnline FROM character_lastonline WHERE character=?", player.name);
        string row = (results != null) ? results.lastOnline.ToString() : "";
        if (!string.IsNullOrWhiteSpace(row)) {
            DateTime time = DateTime.Parse(row);
            player.UCE_SecondsPassed = (DateTime.UtcNow - time).TotalSeconds;
        }
        else {
            player.UCE_SecondsPassed = 0;
        }
#endif
    }

    // -----------------------------------------------------------------------------------
    // CharacterSave_UCE_Sanctuary
    // -----------------------------------------------------------------------------------
    [DevExtMethods("CharacterSave")]
    private void CharacterSave_UCE_Sanctuary(Player player) {
#if _MYSQL && _SERVER
		ExecuteNonQueryMySql("DELETE FROM character_lastonline WHERE `character`=@character", new MySqlParameter("@character", player.name));
        ExecuteNonQueryMySql("INSERT INTO character_lastonline VALUES (@character, @lastOnline)",
				new MySqlParameter("@lastOnline", DateTime.UtcNow.ToString("s")),
				new MySqlParameter("@character", player.name));
#elif _SQLITE && _SERVER
        connection.Execute("DELETE FROM character_lastonline WHERE character=?", player.name);
        connection.Insert(new character_lastonline {
            character = player.name,
            lastOnline = DateTime.UtcNow.ToString()
        });
#endif
    }

    // -----------------------------------------------------------------------------------
}