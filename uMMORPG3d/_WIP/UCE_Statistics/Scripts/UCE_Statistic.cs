// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using System;
using UnityEngine;

// UCE_Statistic

[Serializable]
public partial struct UCE_Statistic
{
    public string name;
    public long amount;
    public long total;
}

public class SyncListUCE_Statistic : SyncList<UCE_Statistic> { }