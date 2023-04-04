// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

#if _UMA

using System.Collections.Generic;
using UnityEngine;

public partial class CharactersAvailableMsg
{
    public partial struct CharacterPreview
    {
        public string umaDna;
    }

    private void Load_UmaIntegration(List<Player> players)
    {
        for (int i = 0; i < players.Count; ++i)
        {
            characters[i].umaDna = players[i].umaDna;
        }
    }
}

#endif