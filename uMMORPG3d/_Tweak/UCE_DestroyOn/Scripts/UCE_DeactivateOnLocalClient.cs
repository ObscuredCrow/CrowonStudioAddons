// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;

// DEACTIVATE ON lOCAL CLIENT

public class UCE_DeactivateOnLocalClient : MonoBehaviour
{
    // -------------------------------------------------------------------------------
    // Start
    // -------------------------------------------------------------------------------
    private void Start()
    {
#if _CLIENT && !_SERVER
        Player player = Player.localPlayer;
        if (player)
            this.gameObject.SetActive(false);
        else
            this.gameObject.SetActive(true);
#else
        this.gameObject.SetActive(true);
#endif
    }

    // -------------------------------------------------------------------------------
}