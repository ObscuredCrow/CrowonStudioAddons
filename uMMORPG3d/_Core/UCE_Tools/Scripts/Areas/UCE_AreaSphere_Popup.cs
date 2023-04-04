// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================


using Mirror;
using UnityEngine;

// ===================================================================================
// POPUP AREA - SPHERE
// ===================================================================================
[RequireComponent(typeof(SphereCollider))]
public partial class UCE_AreaSphere_Popup : NetworkBehaviour
{
#if _CSPVPREALMS

    [Tooltip("Show the messages only to members or allies of this realm")]
    public int realmId;
    public int alliedRealmId;
#endif
    public string messageOnEnter;
    public string messageOnExit;
    [Range(0, 255)] public byte iconId;
    [Range(0, 255)] public byte soundId;

    // -----------------------------------------------------------------------------------
    // OnTriggerEnter
    // @Client
    // -----------------------------------------------------------------------------------
    private void OnTriggerEnter(Collider co)
    {
        if (messageOnEnter != "")
        {
            Player player = co.GetComponentInParent<Player>();
            if (player)
            {
#if _CSPVPREALMS
                if (player.UCE_getAlliedRealms(realmId, alliedRealmId))
                {
#endif
                player.UCE_ShowPopup(messageOnEnter, iconId, soundId);
#if _CSPVPREALMS
                }
#endif
            }
        }
    }

    // -----------------------------------------------------------------------------------
    // OnTriggerExit
    // @Client
    // -----------------------------------------------------------------------------------
    private void OnTriggerExit(Collider co)
    {
        if (messageOnExit != "")
        {
            Player player = co.GetComponentInParent<Player>();
            if (player)
            {
#if _CSPVPREALMS
                if (player.UCE_getAlliedRealms(realmId, alliedRealmId))
                {
#endif

                player.UCE_ShowPopup(messageOnExit, iconId, soundId);
#if _CSPVPREALMS
                }
#endif
            }
        }
    }

    // -----------------------------------------------------------------------------------
}