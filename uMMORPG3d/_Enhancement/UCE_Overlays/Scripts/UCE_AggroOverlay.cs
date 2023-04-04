// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using System.Collections;

// UCE AggroOverlay

public class UCE_AggroOverlay : MonoBehaviour
{
    public GameObject childObject;
    public float hideAfter = 0.5f;

    // -----------------------------------------------------------------------------------
    // Awake
    // -----------------------------------------------------------------------------------
    private void Awake()
    {
        childObject.SetActive(false);
    }

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show()
    {
        childObject.SetActive(true);
        Invoke("Hide", hideAfter);
    }

    // -----------------------------------------------------------------------------------
    // Hide
    // -----------------------------------------------------------------------------------
    public void Hide()
    {
        CancelInvoke();
        childObject.SetActive(false);
    }

    // -----------------------------------------------------------------------------------
}