// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;
using System.Text;
using UnityEngine;
using System.Collections.Generic;

// EQUIPMENT ITEM

public partial class EquipmentItem
{
    [Header("[-=-=- UCE Mesh Switcher -=-=-]")]
    public int[] meshIndex;

    public Material meshMaterial;
    public SwitchableColor[] switchableColors;
}