// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// UCE UI PROMPT

public class UCE_UI_Prompt : MonoBehaviour
{
    public GameObject panel;
    public Text messageText;
    public bool forceUseChat;

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show(string message)
    {
        messageText.text = message;
        panel.SetActive(true);
    }

    // -----------------------------------------------------------------------------------
}