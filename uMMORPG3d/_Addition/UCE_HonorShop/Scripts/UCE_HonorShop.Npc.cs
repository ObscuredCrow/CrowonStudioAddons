// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// NPC

public partial class Npc
{
    [Header("-=-=-=- Honor Shop -=-=-=-")]
    [Tooltip("One click deactivation")]
    public bool offersShop;

    public UCE_HonorShopCategory[] itemShopCategories;
}