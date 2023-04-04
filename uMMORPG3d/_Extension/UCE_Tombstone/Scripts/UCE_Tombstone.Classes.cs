// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE TOMBSTONE

[System.Serializable]
public partial class UCE_Tombstone
{
    public GameObject[] tombstone;
    [Range(0, 1)] public float tombstoneChance = 1.0f;
    [Range(0, 1)] public float tombstoneFallHeight = 0.5f;
}