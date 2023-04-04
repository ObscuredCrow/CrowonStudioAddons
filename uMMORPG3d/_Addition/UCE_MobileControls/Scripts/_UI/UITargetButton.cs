// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// UITargetButton

public class UITargetButton : MonoBehaviour
{
    private Button targetButton;

    private void Start()
    {
        targetButton = GetComponent<Button>();
        if (targetButton != null)
            targetButton.onClick.SetListener(() => SelectTarget());
    }

    private void SelectTarget()
    {
        Player player = Player.localPlayer;
        if (!player) return;
        player.TargetNearestButton();
    }
}