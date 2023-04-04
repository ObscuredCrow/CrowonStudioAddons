// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

public abstract partial class ScriptableSkill
{
    [Tooltip("This skill cannot be learned via the Skill Window, only via other means")]
    public bool unlearnable;

    [Tooltip("Checked = negative skill, Unchecked = positive skill. Certain skills can debuff disadvantageous skills only")]
    public bool disadvantageous;
}