// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;
using System.Linq;

// NETWORKED SWITCH

public partial class UCE_NetworkedSwitch : UCE_InteractableObject
{
    public GameObject[] activatedObjects;
    public bool switched = false;
    public float resetTime = 0;

    // -----------------------------------------------------------------------------------
    // OnInteractClient
    // @Client
    // -----------------------------------------------------------------------------------
    [ClientCallback]
    public override void OnInteractClient(Player player) { }

    // -----------------------------------------------------------------------------------
    // OnInteractServer
    // @Server
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    public override void OnInteractServer(Player player)
    {
        if (resetTime > 0)
        {
            switched = true;
            Invoke("Reset", resetTime);
        }
        else switched = !switched;

        foreach (GameObject go in activatedObjects)
            go.GetComponent<UCE_ActivateableObject>().Toggle(switched);
    }

    private void Reset()
    {
        switched = false;
    }

    // -----------------------------------------------------------------------------------
}