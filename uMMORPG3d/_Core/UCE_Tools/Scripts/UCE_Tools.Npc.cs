// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// ===================================================================================
// NPC
// ===================================================================================
public partial class Npc
{
    // Required to keep track of how many players are within this Npcs interaction range
    [SyncVar, HideInInspector] public int accessingPlayers = 0;
}