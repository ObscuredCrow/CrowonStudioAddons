// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// SHORTCUTS

public partial class UCE_UI_Leaderboard_Shortcuts : MonoBehaviour
{
    public Button LeaderboardButton;
    public GameObject LeaderboardPanel;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    public void Update()
    {
        LeaderboardButton.onClick.SetListener(() =>
        {
            LeaderboardPanel.SetActive(!LeaderboardPanel.activeSelf);
        });
    }

    // -----------------------------------------------------------------------------------
}