// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

#if _CSCRAFTING

// INTERACTABLE WORKBENCH

public partial class UCE_InteractableWorkbench : UCE_InteractableObject
{
    [Header("[ANIMATION & SOUND]")]
    [Tooltip("[Optional] GameObject spawned as effect when successfully crafted (see ReadMe).")]
    public GameObject craftEffect;

    [Tooltip("[Optional] Sound played when successfully crafted.")]
    public AudioClip craftSound;

    [Header("[MESSAGES]")]
    public string levelUpMessage = "Craft level up: ";

    public string nothingMessage = "Nothing to craft!";

    // -----------------------------------------------------------------------------------
    // OnInteractClient
    // @Client
    // -----------------------------------------------------------------------------------
    [ClientCallback]
    public override void OnInteractClient(Player player)
    {
        player.UCE_OnSelect_InteractableWorkbench(this);
    }

    // -----------------------------------------------------------------------------------
    // OnCrafted
    // -----------------------------------------------------------------------------------
    public void OnCrafted()
    {
        SpawnEffect(craftEffect, craftSound);
    }

    // -----------------------------------------------------------------------------------
}

#endif