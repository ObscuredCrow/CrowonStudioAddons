// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UCE JUKEBOX

[CreateAssetMenu(fileName = "UCE Jukebox", menuName = "UCE/Template/Jukebox", order = 0)]
public class UCE_Tmpl_Jukebox : ScriptableObject
{
    [Header("-=-=-=- UCE JUKEBOX -=-=-=-")]
    public bool isActive;

    [Header("[MENU MUSIC (Only functional on compiled client)]")]
    [Tooltip("This music plays (looped) while the player is not logged in")]
    public AudioClip menuMusicClip;

    public float menuFadeInFadeOut = 1.0f;
    [Range(0, 1)] public float menuAdjustedVol = 1.0f;

    [Header("[DEFAULT GAME MUSIC]")]
    [Tooltip("This music plays (looped) while logged in but not inside any music area")]
    public AudioClip defaultMusicClip;

    public float defaultFadeInFadeOut = 1.0f;
    [Range(0, 1)] public float defaultAdjustedVol = 1.0f;
}