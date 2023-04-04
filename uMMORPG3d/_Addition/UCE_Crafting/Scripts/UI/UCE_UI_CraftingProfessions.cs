// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

#if _CSCRAFTING

// ===================================================================================
// CRAFTING UI
// ===================================================================================
public partial class UCE_UI_CraftingProfessions : MonoBehaviour
{
    public GameObject panel;
    public Transform content;
    public UCE_UI_CraftingSlot slotPrefab;
    public KeyCode hotKey = KeyCode.H;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        // hotkey (not while typing in chat, etc.)
        if (Input.GetKeyDown(hotKey) && !UIUtils.AnyInputActive())
            panel.SetActive(!panel.activeSelf);

        if (panel.activeSelf && player.UCE_Crafts.Count > 0)
        {
            UIUtils.BalancePrefabs(slotPrefab.gameObject, player.UCE_Crafts.Count, content);

            for (int i = 0; i < content.childCount; i++)
            {
                content.GetChild(i).GetComponent<UCE_UI_CraftingSlot>().Show(player.UCE_Crafts[i]);
            }
        }
    }
}

#endif