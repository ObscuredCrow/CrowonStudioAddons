// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE ADMINISTRATION - CLASSES

// ---------------------------------------------------------------------------------------
// UCE_AdminCommandArgument
// ---------------------------------------------------------------------------------------
[System.Serializable]
public class UCE_AdminCommandArgument
{
    public enum UCE_AdminCommandArgumentType
    {
        TargetType,
        AnyName,
        PlayerName,
        ItemName,
        Integer,
        AnyText,
        MonsterName,
        NpcName
    }

    public UCE_AdminCommandArgumentType argumentType;
}

// ---------------------------------------------------------------------------------------
// UCE_AdminCommandList
// ---------------------------------------------------------------------------------------
[System.Serializable]
public class UCE_AdminCommandList
{
    [Header("-=-=-=- Commands -=-=-=-")]
    public UCE_Tmpl_AdminCommand[] commands;

    [Header("-=-=-=- Target Tags -=-=-=-")]
    public string tagTargetPlayer = "t";

    public string tagTargetParty = "p";
    public string tagTargetGuild = "g";
    public string tagTargetRealm = "r";
    public string tagTargetAll = "a";
}