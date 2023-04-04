// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// DATABASE CLEANER

[CreateAssetMenu(fileName = "UCE WordFilter", menuName = "UCE/Template/Word Filter", order = 0)]
public class UCE_Tmpl_WordFilter : ScriptableObject
{
    [Tooltip("[Required] Enter all bad words here. If a chatext or player name contains one of them, it will be denied.")]
    public string[] badwords;
}