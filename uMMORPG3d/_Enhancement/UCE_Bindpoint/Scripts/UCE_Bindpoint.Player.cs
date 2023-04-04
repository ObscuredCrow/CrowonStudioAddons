// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

// PLAYER

public partial class Player
{
    [HideInInspector, SyncVar] public UCE_BindPoint UCE_myBindpoint;

    // -----------------------------------------------------------------------------------
    // UCE_SetBindpoint
    // @Server
    // -----------------------------------------------------------------------------------
    public void UCE_SetBindpointFromArea(string name, float x, float y, float z)
    {
        if (isAlive)
        {
            UCE_myBindpoint = new UCE_BindPoint();
            UCE_myBindpoint.name = name;
            UCE_myBindpoint.position = new Vector3(x, y, z);
            UCE_myBindpoint.SceneName = SceneManager.GetActiveScene().name;
        }
    }

    // -----------------------------------------------------------------------------------
    // Cmd_UCE_SetBindpoint
    // @Client -> @Server
    // -----------------------------------------------------------------------------------
    [Command]
    public void Cmd_UCE_SetBindpoint()
    {
        if (state == "IDLE" &&
            target != null &&
            target.isAlive &&
            isAlive &&
            target is Npc &&
            Utils.ClosestDistance(this, target) <= interactionRange &&
            ((Npc)target).bindpoint != null)
        {
            UCE_myBindpoint.name = ((Npc)target).bindpoint.gameObject.name;
            UCE_myBindpoint.position = new Vector3(((Npc)target).bindpoint.position.x, ((Npc)target).bindpoint.position.y, ((Npc)target).bindpoint.position.z);
            UCE_myBindpoint.SceneName = SceneManager.GetActiveScene().name;
        }
    }

    // -----------------------------------------------------------------------------------
    // Cmd_UCE_RespawnToBindpoint
    // @Client -> @Server
    // -----------------------------------------------------------------------------------
    [Command]
    public void Cmd_UCE_RespawnToBindpoint()
    {
        if (!UCE_myBindpoint.Valid) return;

#if _CSNETWORKZONES && _CSBINDPOINT
        // -- same scene
        if (UCE_myBindpoint.SceneName == SceneManager.GetActiveScene().name)
        {
            UCE_RespawnToLocalBindpoint();
        }
        else // -- other scene
        {
            UCE_RespawnToRemoteBindpoint();
        }
#else
		// -- only same scene without network zones
		UCE_RespawnToLocalBindpoint();
#endif
    }

    // -----------------------------------------------------------------------------------
    // UCE_RespawnToLocalBindpoint
    // @Server
    // -----------------------------------------------------------------------------------
    public void UCE_RespawnToLocalBindpoint()
    {
        agent.Warp(UCE_myBindpoint.position);
        Revive(0.5f);
        UCE_OverrideState("IDLE");
    }

    // -----------------------------------------------------------------------------------
    // UCE_RespawnToRemoteBindpoint
    // @Server
    // -----------------------------------------------------------------------------------
#if _CSNETWORKZONES && _CSBINDPOINT

    public void UCE_RespawnToRemoteBindpoint()
    {
        Revive(0.5f);
        UCE_OverrideState("IDLE");
        UCE_OnPortal(UCE_myBindpoint);
    }

#endif

    // -----------------------------------------------------------------------------------
}