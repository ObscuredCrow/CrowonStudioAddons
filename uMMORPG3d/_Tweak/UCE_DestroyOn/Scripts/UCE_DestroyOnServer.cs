// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;

// DESTROY ON SERVER

public class UCE_DestroyOnServer : MonoBehaviour
{
    // -------------------------------------------------------------------------------
    // Start
    // -------------------------------------------------------------------------------
    private void Start()
    {
        NetworkBehaviour source = GetComponentInParent<NetworkBehaviour>();

        if (source && NetworkServer.active)
            Destroy(this.gameObject);
    }

    // -------------------------------------------------------------------------------
}