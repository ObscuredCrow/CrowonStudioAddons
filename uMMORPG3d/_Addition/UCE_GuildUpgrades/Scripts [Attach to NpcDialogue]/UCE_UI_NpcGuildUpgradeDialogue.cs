// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// UCE UI NPC GUILD UPGRADE DIALOGUE

public class UCE_UI_NpcGuildUpgradeDialogue : MonoBehaviour
{
    public GameObject panel;
    public Button guildUpgradeButton;
    public GameObject guildUpgradePanel;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (player.target != null &&
            player.target is Npc &&
            Utils.ClosestDistance(player, player.target) <= player.interactionRange)
        {
            Npc npc = (Npc)player.target;

            guildUpgradeButton.gameObject.SetActive(npc.checkGuildUpgradeAccess(player));

            guildUpgradeButton.onClick.SetListener(() =>
            {
                guildUpgradePanel.SetActive(true);
                panel.SetActive(false);
            });
        }
        else
        {
            guildUpgradePanel.SetActive(false);
        }
    }

    // -----------------------------------------------------------------------------------
}