// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// UCE_UI_PlaceableObjectSpawn

public partial class UCE_UI_PlaceableObjectSpawn : MonoBehaviour
{
    public GameObject panel;
    public Button acceptButton;
    public Button declineButton;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        if (!panel.activeSelf) return;

        Player player = Player.localPlayer;
        if (!player) return;

        if (panel.activeSelf &&
            player.isAlive && player.state == "IDLE")
        {
            // -- Spawn Structure
            acceptButton.gameObject.SetActive(player.UCE_CanSpawnPlaceableObject());
            acceptButton.onClick.SetListener(() =>
            {
                player.Cmd_StartSpawnPlaceableObject();
                panel.SetActive(false);
            });

            // -- Cancel Spawn Structure
            declineButton.onClick.SetListener(() =>
            {
                player.UCE_CancelSpawnPlaceableObject();
                panel.SetActive(false);
            });
        }
        else
        {
            panel.SetActive(false);
        }
    }

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show()
    {
        panel.SetActive(true);
    }

    // -----------------------------------------------------------------------------------
}