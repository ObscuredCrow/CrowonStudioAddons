// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;

// TRAVELROUTE - CLASS

[System.Serializable]
public struct UCE_TravelrouteClass
{
    public string name;

    public UCE_TravelrouteClass(string _name)
    {
        name = _name;
    }
}

public class SyncListUCE_TravelrouteClass : SyncList<UCE_TravelrouteClass> { }