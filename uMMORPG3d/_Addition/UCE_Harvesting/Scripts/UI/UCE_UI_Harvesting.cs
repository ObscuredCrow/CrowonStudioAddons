// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

#if _CSHARVESTING

// ===================================================================================
// UCE UI HARVESTING
// ===================================================================================
public partial class UCE_UI_Harvesting : MonoBehaviour
{
    public GameObject panel;
    public Transform content;
    public UCE_UI_HarvestingSlot slotPrefab;
    public KeyCode hotKey = KeyCode.H;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (Input.GetKeyDown(hotKey) && !UIUtils.AnyInputActive())
            panel.SetActive(!panel.activeSelf);

        if (panel.activeSelf && player.UCE_Professions.Count > 0)
        {
            UIUtils.BalancePrefabs(slotPrefab.gameObject, player.UCE_Professions.Count, content);

            for (int i = 0; i < content.childCount; i++)
            {
                content.GetChild(i).GetComponent<UCE_UI_HarvestingSlot>().Show(player.UCE_Professions[i]);
            }
        }
    }

    // -----------------------------------------------------------------------------------
}

#endif