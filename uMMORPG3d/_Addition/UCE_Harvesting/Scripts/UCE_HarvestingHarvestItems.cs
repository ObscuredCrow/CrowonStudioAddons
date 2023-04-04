// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// HARVEST ITEMS

[System.Serializable]
public class UCE_HarvestingHarvestItems
{
    public ScriptableItem template;
    [Range(0, 1)] public float probability;
    [Range(1, 999)] public int minAmount = 1;
    [Range(1, 999)] public int maxAmount = 1;
}