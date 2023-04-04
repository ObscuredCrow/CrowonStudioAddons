// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using Mirror;
using System;
using System.Linq;
using System.Collections;

// UCE_IndicatorProjector

public partial class UCE_IndicatorProjector : MonoBehaviour
{
    public GameObject indicatorProjector;
    public float hideAfter;

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show()
    {
        if (indicatorProjector)
        {
            indicatorProjector.gameObject.SetActive(true);
            Invoke("Hide", hideAfter);
        }
    }

    // -----------------------------------------------------------------------------------
    // Hide
    // -----------------------------------------------------------------------------------
    public void Hide()
    {
        if (indicatorProjector)
            indicatorProjector.gameObject.SetActive(false);
    }

    // -----------------------------------------------------------------------------------
}