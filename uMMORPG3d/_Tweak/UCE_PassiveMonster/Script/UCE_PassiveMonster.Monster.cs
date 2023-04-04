// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Monster
{
    #region Variables

    [Header("[-=-=- PASSIVE MONSTER	-=-=-]")]
    public bool isPassive = false;

    public bool isAfraid = false;
    public float healthThreshold = 0.9f;
    public int runDistance = 50;

    private bool canRun = false;
    private float updateRate = 1, updateNext = 0;

    #endregion Variables

    // If monster is low on health and afraid then flee.
    // If monster is passive then flee.
    private bool EventRunaway()
    {
        if (Time.time > updateNext) { updateNext = Time.time + updateRate; canRun = true; }
        else canRun = false;

        return HealthPercent() < healthThreshold && (isPassive || isAfraid) && canRun;
    }

    // Runaway in a random direction based on normal move distance.
    private string Runaway()
    {
        Vector2 circle2D = Random.insideUnitCircle * runDistance;
        agent.stoppingDistance = 0;
        agent.destination = startPosition + new Vector3(circle2D.x, 0, circle2D.y);
        return "MOVING";
    }
}