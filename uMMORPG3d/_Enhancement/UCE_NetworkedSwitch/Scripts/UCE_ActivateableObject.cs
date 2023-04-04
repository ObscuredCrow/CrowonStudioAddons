// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;
using System.Linq;

// ACTIVATEABLE OBJECT

public partial class UCE_ActivateableObject : NetworkBehaviour
{
    [Tooltip("[Required] Link the activated game object here (its usually a child of this)")]
    public GameObject activateableObject;

    [Tooltip("[Required] Is the linked object visible by default or not?")]
    [SyncVar] public bool _visible = false;

    [Tooltip("[Optional] Automatic reset to default visibility after x seconds (0 to disable)")]
    public float resetVisibility = 0;

#if _CSWORLDEVENTS

    [Header("[UCE WORLD EVENT (object visibility is based on event status)]")]
    [Tooltip("[Optional] This world event will be checked")]
    public UCE_WorldEventTemplate worldEvent;

    [Tooltip("[Optional] Min count the world event has been completed (0 to disable)")]
    public int minEventCount;

    [Tooltip("[Optional] Max count the world event has been completed (0 to disable)")]
    public int maxEventCount;

#endif

    // -----------------------------------------------------------------------------------
    // Start
    // -----------------------------------------------------------------------------------
    private void Start()
    {
#if _CSWORLDEVENTS
        if (worldEvent != null)
            _visible = NetworkManagerMMO.UCE_CheckWorldEvent(worldEvent, minEventCount, maxEventCount);
#endif
        Reset();
        activateableObject.GetComponent<MeshRenderer>().enabled = true;
    }

    // -----------------------------------------------------------------------------------
    // Toggle
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    public void Toggle(bool visible)
    {
        activateableObject.SetActive(visible);
        if (resetVisibility > 0)
            Invoke("Reset", resetVisibility);
    }

    // -----------------------------------------------------------------------------------
    // Reset
    // -----------------------------------------------------------------------------------
    public void Reset()
    {
        activateableObject.SetActive(_visible);
    }

    // -----------------------------------------------------------------------------------
}