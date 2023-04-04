// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

public class UCE_UI_LogoutTimer_Popup : MonoBehaviour
{
    public GameObject panel;

    public static UCE_UI_LogoutTimer_Popup singleton;

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    private void Start()
    {
        if (singleton == null) singleton = this;
    }

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show()
    {
        if (panel.activeSelf) return;
        panel.SetActive(true);
    }

    // -----------------------------------------------------------------------------------
    // Hide
    // -----------------------------------------------------------------------------------
    public void Hide()
    {
        if (!panel.activeSelf) return;
        panel.SetActive(false);
    }

    // -----------------------------------------------------------------------------------
}