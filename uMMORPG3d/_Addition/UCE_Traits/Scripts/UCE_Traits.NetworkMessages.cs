// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// Contains all the network messages that we need.
using Mirror;

// client to server ////////////////////////////////////////////////////////////
public partial class CharacterCreateMsg : MessageBase
{
    public int[] traits;
}