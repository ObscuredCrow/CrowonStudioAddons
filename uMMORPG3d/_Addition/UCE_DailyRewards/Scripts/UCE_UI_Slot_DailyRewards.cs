// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// ===================================================================================
// DAILY REWARDS UI SLOT
// ===================================================================================
public partial class UCE_UI_Slot_DailyRewards : MonoBehaviour
{
    public Image slotIcon;
    public Text slotText;

    // -----------------------------------------------------------------------------------
    // AddMessage
    // -----------------------------------------------------------------------------------
    public void AddMessage(string msg, Color color, Sprite icon = null)
    {
        slotText.color = color;
        slotText.text = msg;
        slotIcon.sprite = icon;
    }
}