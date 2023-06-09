// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// Travelroute

[System.Serializable]
public class UCE_Travelroute
{
    [Header("[-=-=-=- UCE TRAVELROUTE -=-=-=-]")]
    [Tooltip("[Required] Any on scene Transform or GameObject OR off scene coordinates (requires UCE Network Zones AddOn)")]
    public UCE_TeleportationTarget teleportationTarget;

    [Tooltip("[Optional] Price calculated based on distance of current position and destination (or fixed price on off scene)")]
    public float GoldPricePerUnit;

#if _CSHONORSHOP

    [Header("-=-=-=- UCE Honor Currency Cost -=-=-=-")]
    [Tooltip("[Optional] Total price is calculated based on distance of current position and destination")]
    public UCE_HonorShopCurrencyCost[] currencyCost;

#endif
}