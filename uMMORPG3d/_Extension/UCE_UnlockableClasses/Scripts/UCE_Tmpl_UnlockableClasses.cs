// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// DEFAULT UNLOCKED CLASSES

[CreateAssetMenu(fileName = "UCE Default Unlocked Classes", menuName = "UCE/Template/Default Unlocked Classes", order = 0)]
public class UCE_Tmpl_UnlockableClasses : ScriptableObject
{
    [Tooltip("[Required] Default classes available to all players")]
    public Player[] defaultClasses;
}