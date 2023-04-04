// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// ACTIVATION REQUIREMENTS CLASS
// THIS CLASS IS FOR OBJECTS THAT ARE ACTIVATED AUTOMATICALLY IF CERTAIN CRITERIA ARE MET

[System.Serializable]
public partial class UCE_ActivationRequirements : UCE_Requirements
{
#if _CSBUILDSYSTEM

    [Header("[UCE BUILD SYTEM REQUIREMENTS]")]
    [Tooltip("[Optional] Build System - only the owner character of the structure can access it?")]
    public bool ownerCharacterOnly;

    [Tooltip("[Optional] Build System - only the owner guild of the structure can access it?")]
    public bool ownerGuildOnly;

    [Tooltip("[Optional] Build System - will reverse both checks from above and only activate when non owner / non guild members access")]
    public bool reverseCheck;
#endif

    protected GameObject parent;

    // -----------------------------------------------------------------------------------
    // setParent
    // -----------------------------------------------------------------------------------
    public void setParent(GameObject myParent)
    {
        parent = myParent;
    }

    // -----------------------------------------------------------------------------------
    // CheckRequirements
    // -----------------------------------------------------------------------------------
    public override bool CheckRequirements(Player player)
    {
        bool valid = true;

        valid = base.CheckRequirements(player);

#if _CSBUILDSYSTEM
        valid = (checkBuildSystem(player) == true) ? valid : false;
#endif

        return valid;
    }

    // -----------------------------------------------------------------------------------
    // checkBuildSystem
    // -----------------------------------------------------------------------------------
#if _CSBUILDSYSTEM

    public bool checkBuildSystem(Player player)
    {
        if (!parent || !parent.GetComponentInParent<UCE_PlaceableObject>()) return true;

        UCE_PlaceableObject po = parent.GetComponentInParent<UCE_PlaceableObject>();

        if (po == null || (!ownerCharacterOnly && !ownerGuildOnly)) return true;

        return
                (!ownerCharacterOnly || (!reverseCheck && ownerCharacterOnly && player.name == po.ownerCharacter || reverseCheck && ownerCharacterOnly && player.name != po.ownerCharacter)) &&
                (!ownerGuildOnly || (!reverseCheck && ownerGuildOnly && player.guild.name == po.ownerGuild || reverseCheck && ownerGuildOnly && player.guild.name != po.ownerGuild));
    }

#endif

    // -----------------------------------------------------------------------------------
}