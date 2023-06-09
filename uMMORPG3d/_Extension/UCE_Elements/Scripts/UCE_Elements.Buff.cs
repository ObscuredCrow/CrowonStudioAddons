// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Linq;

// BUFF

public partial struct Buff
{
    public LevelBasedElement[] elementalResistances { get { return data.elementalResistances; } }

    public float GetResistance(UCE_ElementTemplate element)
    {
        return elementalResistances.FirstOrDefault(x => x.template == element).Get(level);
    }
}