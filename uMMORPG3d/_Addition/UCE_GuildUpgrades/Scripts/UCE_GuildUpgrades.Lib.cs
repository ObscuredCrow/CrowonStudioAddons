// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

public partial class UCE_DefinesManager
{
    [DevExtMethods("Constructor")]
    public static void Constructor_UCE_GuildUpgrades()
    {
        UCE_AddOn addon = new UCE_AddOn();

        addon.name = "UCE Guild Upgrades";
        addon.basis = "uMMORPG3d";
        addon.define = "_CSGUILDUPGRADES";
        addon.author = "Crowon Studio";
        addon.version = "2021.100";
        addon.dependencies = "UCE Guild Warehouse";
        addon.comments = "none";
        addon.active = true;

        addons.Add(addon);
    }
}

#endif