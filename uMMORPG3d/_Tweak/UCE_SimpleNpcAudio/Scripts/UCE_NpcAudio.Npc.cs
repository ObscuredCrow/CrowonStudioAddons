// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Npc
{
    [Header("[-=-=-=- NPC AUDIO -=-=-=-]")]
    public AudioClip interactAudio;
    public AudioClip questAudio;

    public void PlayInteractSound()
    {
        AudioSource tempSource = GetComponentInParent<AudioSource>();
        if (tempSource == null) return;

        tempSource.PlayOneShot(interactAudio);
    }

    public void PlayQuestAudio()
    {
        AudioSource tempSource = GetComponentInParent<AudioSource>();
        if (tempSource == null) return;

        tempSource.PlayOneShot(questAudio);
    }
}

public partial class UINpcDialogue
{
    public void InteractAudio()
    {
        Player player = Player.localPlayer;
        if (player == null || player.target == null) return;

        if (player.target is Npc)
        {
            Npc npc = (Npc)player.target;
            if (npc.interactAudio == null) return;
            npc.PlayInteractSound();
        }
    }

    public void QuestAudio()
    {
        Player player = Player.localPlayer;
        if (player == null || player.target == null) return;

        if (player.target is Npc)
        {
            Npc npc = (Npc)player.target;
            if (npc.questAudio == null) return;
            npc.PlayQuestAudio();
        }
    }
}