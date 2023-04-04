// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// ===================================================================================
// FRIENDLIST TARGET
// ===================================================================================
public partial class UCE_UI_Friendlist_Target : MonoBehaviour
{
    public Button friendAddButton;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        Player player = Player.localPlayer;
        if (!player) return;

#if _CSPVPREALMS
        if (player.target && player.target is Player && player.target != player && player.UCE_SameRealm((Player)player.target))
        {
            friendAddButton.gameObject.SetActive(true);
            friendAddButton.interactable = player.UCE_Friends.FindIndex(x => x.name == ((Player)(player.target)).name) == -1 ? true : false;
            friendAddButton.onClick.SetListener(() =>
            {
                player.Cmd_UCE_AddFriend(((Player)(player.target)).name);
            });
        }
        else friendAddButton.gameObject.SetActive(false);
#else
        if (player.target && player.target is Player && player.target != player)
        {
            friendAddButton.gameObject.SetActive(true);
            friendAddButton.interactable = player.UCE_Friends.FindIndex(x => x.name == ((Player)(player.target)).name) == -1 ? true : false;
            friendAddButton.onClick.SetListener(() =>
            {
                player.Cmd_UCE_AddFriend(((Player)(player.target)).name);
            });
        }
        else friendAddButton.gameObject.SetActive(false);
#endif
    }

    // -----------------------------------------------------------------------------------
}