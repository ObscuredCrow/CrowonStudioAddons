// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;
using UnityEngine;

// UCE ITEM DROP CHANCE

[Serializable]
public class UCE_ItemDropChance
{
    public ScriptableItem item;
    [Range(0, 1)] public float probability;
    public UCE_ActivationRequirements dropRequirements;
}