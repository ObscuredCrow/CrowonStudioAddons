// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

public abstract partial class ScriptableSkill
{
#if _CSSTAMINA

    [Tooltip("Stamina Special Rule: Can be cast with insufficient stamina as well!")]
    public LinearInt staminaCosts;

#endif
}