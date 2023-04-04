// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

public partial class EquipmentItem : UsableItem
{
    [Header("-=-=- UCE Usage Requirements -=-=-")]
    [Tooltip("While equipped, allows the usage of skills with the same ID (0 = disabled)")]
    public int usageEquipmentId;
}