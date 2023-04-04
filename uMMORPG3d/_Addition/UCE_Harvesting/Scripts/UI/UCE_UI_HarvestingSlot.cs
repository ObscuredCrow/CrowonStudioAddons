// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

#if _CSHARVESTING

// HARVESTING SLOT

public class UCE_UI_HarvestingSlot : MonoBehaviour
{
    public Text nameText;
    public Image professionIcon;
    public Slider expSlider;
    public UIShowToolTip tooltip;

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show(UCE_HarvestingProfession p)
    {
        float value = 0;

        string lvl = " [L" + p.level.ToString() + "/" + p.maxlevel.ToString() + "]";

        value = p.experiencePercent;

        nameText.text = p.template.name + lvl;
        professionIcon.sprite = p.template.image;
        expSlider.value = value;

        tooltip.enabled = true;
        tooltip.text = ToolTip(p.template);
    }

    // -----------------------------------------------------------------------------------
    // ToolTip
    // -----------------------------------------------------------------------------------
    public string ToolTip(UCE_HarvestingProfessionTemplate tpl)
    {
        return tpl.ToolTip();
    }

    // -----------------------------------------------------------------------------------
}

#endif