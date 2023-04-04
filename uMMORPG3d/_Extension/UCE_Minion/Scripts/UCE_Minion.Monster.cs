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

// MONSTER

public partial class Monster
{
    [Header("[-=-=-=- UCE MINION -=-=-=-=-]")]
    public GameObject myMaster;

    public bool followMaster;
    public bool boundToMaster;

    // -----------------------------------------------------------------------------------
    // LateUpdate_UCE_Minion
    // -----------------------------------------------------------------------------------
    [DevExtMethods("LateUpdate")]
    private void LateUpdate_UCE_Minion()
    {
        if (myMaster != null && isAlive)
        {
            if (followMaster)
                startPosition = myMaster.transform.position;

            if (boundToMaster && myMaster.GetComponent<Entity>() != null)
            {
                if (!myMaster.GetComponent<Entity>().isAlive)
                    health = 0;
            }
        }
    }

    // -----------------------------------------------------------------------------------
}