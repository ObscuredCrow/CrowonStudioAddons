// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// UCE UI PLAYER WAREHOUSE UPGRADE PANEL

public partial class UCE_UI_PlayerWarehouseUpgradePanel : MonoBehaviour
{
    public GameObject panel;
    public Button acceptButton;
    public Button declineButton;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        // use collider point(s) to also work with big entities
        if (player.target != null && player.target is Npc &&
            Utils.ClosestDistance(player, player.target) <= player.interactionRange)
        {
            acceptButton.interactable = player.UCE_CanUpgradePlayerWarehouse();

            acceptButton.onClick.SetListener(() =>
            {
                player.Cmd_UCE_UpgradePlayerWarehouse();
                panel.SetActive(false);
            });

            declineButton.onClick.SetListener(() =>
            {
                panel.SetActive(false);
            });
        }
        else panel.SetActive(false);
    }

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
    }

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Hide()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
    }

    // -----------------------------------------------------------------------------------
}