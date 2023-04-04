// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// SHORTCUTS

public partial class UCE_UI_Friendship_Shortcuts : MonoBehaviour
{
    public Button FriendshipButton;
    public GameObject FriendshipPanel;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    public void Update()
    {
        FriendshipButton.onClick.SetListener(() =>
        {
            FriendshipPanel.SetActive(!FriendshipPanel.activeSelf);
        });
    }

    // -----------------------------------------------------------------------------------
}