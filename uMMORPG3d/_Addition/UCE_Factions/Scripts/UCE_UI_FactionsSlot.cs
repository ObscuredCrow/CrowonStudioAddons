// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// ===================================================================================
// HARVESTING SLOT
// ===================================================================================
public class UCE_UI_FactionsSlot : MonoBehaviour
{
    public Text nameText;
    public Image factionIcon;
    public Slider ratingSlider;
    public UIShowToolTip tooltip;

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show(UCE_Faction faction)
    {
        UCE_Tmpl_Faction data = faction.data;

        nameText.text = data.name + " [" + data.getRank(faction.rating) + "]";
        factionIcon.sprite = data.image;
        ratingSlider.value = faction.rating;

        tooltip.enabled = true;
        tooltip.text = data.name + " [" + faction.rating.ToString() + " " + data.getRank(faction.rating) + "]\n" + data.description;
    }

    // -----------------------------------------------------------------------------------
}