// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Text.RegularExpressions;
using UnityEngine;

//

public partial class NetworkManagerMMO
{
    [Header("-=-=- UCE WORD FILTER -=-=-")]
    public UCE_Tmpl_WordFilter wordFilter;

    // -----------------------------------------------------------------------------------
    // IsAllowedCharacterName
    // -----------------------------------------------------------------------------------
    public bool IsAllowedCharacterName(string characterName)
    {
        if (string.IsNullOrWhiteSpace(characterName)) return false;

        if (wordFilter == null || wordFilter.badwords.Length == 0) return true;

        return characterName.Length <= characterNameMaxLength &&
                Regex.IsMatch(characterName, @"^[a-zA-Z0-9_]+$") &&
                UCE_WordFilter(characterName.ToLower());
    }

    // -----------------------------------------------------------------------------------
    // UCE_WordFilter
    // -----------------------------------------------------------------------------------
    public bool UCE_WordFilter(string text)
    {
        foreach (string badword in wordFilter.badwords)
        {
            if (text.Contains(badword.ToLower()))
                return false;
        }

        return true;
    }

    // -----------------------------------------------------------------------------------
}