// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UCE UI QUEST NPC DIALOGUE

public partial class UCE_UI_Quests_NpcDialogue : MonoBehaviour
{
    public GameObject panel;
    public Button questsButton;
    public GameObject npcQuestPanel;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (panel.activeSelf &&
            player.target != null && player.target is Npc &&
            Utils.ClosestDistance(player, player.target) <= player.interactionRange)
        {
            Npc npc = (Npc)player.target;

            player.UCE_IncreaseQuestNpcCounterFor(npc);

            // filter out the quests that are available for the player
            List<UCE_ScriptableQuest> questsAvailable = npc.UCE_QuestsVisibleFor(player);
            questsButton.gameObject.SetActive(questsAvailable.Count > 0);
            questsButton.onClick.SetListener(() =>
            {
                npcQuestPanel.SetActive(true);
                panel.SetActive(false);
            });
        }
        else panel.SetActive(false); // hide
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