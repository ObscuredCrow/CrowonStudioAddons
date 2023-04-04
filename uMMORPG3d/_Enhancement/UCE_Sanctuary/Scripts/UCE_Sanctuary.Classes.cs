// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;
using UnityEngine;

// UCE_Sanctuary_HonorCurrency

#if _CSHONORSHOP

[Serializable]
public partial struct UCE_Sanctuary_HonorCurrency
{
    public UCE_Tmpl_HonorCurrency honorCurrency;

    [Tooltip("[Optional] Seconds spent offline to gain 1 Honor Currency unit")]
    public int SecondsPerUnit;

    [Tooltip("[Optional] Max. Honor Currency cap offline per session (set 0 to disable)")]
    public int MaxUnits;
}

#endif