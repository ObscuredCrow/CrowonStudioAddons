// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE_UI_NpcExtendedText_Dialogue

public partial class UCE_UI_NpcExtendedText_Dialogue : MonoBehaviour
{
    public GameObject panel;

    protected bool init;

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
            if (!init)
            {
                Npc npc = (Npc)player.target;
                npc.welcome = npc.UCE_UpdateNpcExtendedText(player);
                init = true;
            }
        }
        else
        {
            init = false;
        }
    }

    // -----------------------------------------------------------------------------------
}