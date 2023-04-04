// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;

// UCE TIMEGATE

[System.Serializable]
public struct UCE_TimeGate
{
    public string name;
    public int count;
    public string hours;
    public bool valid;
}

public class SyncListUCE_TimeGate : SyncList<UCE_TimeGate> { }