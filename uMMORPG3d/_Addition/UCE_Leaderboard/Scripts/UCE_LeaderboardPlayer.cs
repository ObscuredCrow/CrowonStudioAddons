// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using System;

// ===================================================================================
// UCE Leaderboard Player
// ===================================================================================
[Serializable]
public partial struct UCE_LeaderboardPlayer
{
    public string name;
    public int rank;
    public int level;
    public long gold;

    // -------------------------------------------------------------------------------
    // UCE_Quest (Constructor)
    // -------------------------------------------------------------------------------
    public UCE_LeaderboardPlayer(string _name, int _level, long _gold)
    {
        name = _name;
        level = _level;
        gold = _gold;
        rank = 0;

        rank = calculateRank();
    }

    // -------------------------------------------------------------------------------
    //
    // -------------------------------------------------------------------------------
    public int calculateRank()
    {
        return 0;
    }

    // -------------------------------------------------------------------------------
}

public class SyncListUCE_LeaderboardPlayer : SyncList<UCE_LeaderboardPlayer> { }