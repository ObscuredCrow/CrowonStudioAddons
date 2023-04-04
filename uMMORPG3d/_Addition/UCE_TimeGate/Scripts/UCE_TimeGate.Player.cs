// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using System;
using UnityEngine;

// PLAYER

public partial class Player
{
    [HideInInspector] public SyncListUCE_TimeGate UCE_timegates = new SyncListUCE_TimeGate();
    [HideInInspector] public UCE_Area_TimeGate UCE_myTimegate;

    // -----------------------------------------------------------------------------------
    // Cmd_UCE_SimpleTimegate
    // @Client -> @Server
    // -----------------------------------------------------------------------------------
    [Command]
    public void Cmd_UCE_SimpleTimegate()
    {
        if (state == "IDLE" && validateTimegate())
        {
            UCE_setSimpleTimegate(UCE_myTimegate);
            UCE_myTimegate.teleportationTarget.OnTeleport(this);
        }
    }

    // -----------------------------------------------------------------------------------
    // validateTimegate
    // -----------------------------------------------------------------------------------
    private bool validateTimegate()
    {
        bool valid = false;
        if (UCE_myTimegate)
        {
            valid = (UCE_myTimegate.teleportationTarget.Valid) ? true : false;
            valid = (isAlive) ? true : false;
            valid = (UCE_myTimegate.dayStart == 0 || UCE_myTimegate.dayStart >= DateTime.UtcNow.Day) ? true : false;
            valid = (UCE_myTimegate.dayEnd == 0 || UCE_myTimegate.dayEnd <= DateTime.UtcNow.Day) ? true : false;
            valid = (UCE_myTimegate.activeMonth == 0 || UCE_myTimegate.activeMonth == DateTime.UtcNow.Month) ? true : false;

            int idx = UCE_GetTimegateIndexByName(UCE_myTimegate.name);

            if (idx > -1 && UCE_timegates[idx].valid)
            {
                valid = ((UCE_myTimegate.maxVisits == 0 || UCE_myTimegate.hoursBetweenVisits == 0) || UCE_timegates[idx].count < UCE_myTimegate.maxVisits && UCE_validateTimegateTime(UCE_timegates[idx].hours, UCE_myTimegate.hoursBetweenVisits));
            }
        }
        return valid;
    }

    // -----------------------------------------------------------------------------------
    // validateTimegateTime
    // -----------------------------------------------------------------------------------
    public bool UCE_validateTimegateTime(string timestamp, int Hours)
    {
        if (Hours > 0)
        {
            DateTime time = DateTime.Parse(timestamp);
            double HoursPassed = (DateTime.UtcNow - time).TotalHours;
            return (HoursPassed >= Hours) ? true : false;
        }
        return true;
    }

    // -----------------------------------------------------------------------------------
    // UCE_GetTimegateIndexByName
    // -----------------------------------------------------------------------------------
    public int UCE_GetTimegateIndexByName(string gateName)
    {
        return UCE_timegates.FindIndex(t => t.name == gateName);
    }

    // -----------------------------------------------------------------------------------
    // UCE_setSimpleTimegate
    // -----------------------------------------------------------------------------------
    private void UCE_setSimpleTimegate(UCE_Area_TimeGate targetTimegate)
    {
        // ---------- Update only if either Visits or Hours is set
        if (targetTimegate.maxVisits != 0 || targetTimegate.hoursBetweenVisits != 0)
        {
            bool done = false;
            int idx = UCE_GetTimegateIndexByName(targetTimegate.name);

            // -- Update existing Timegate entry
            if (idx > -1 && UCE_timegates[idx].valid && UCE_timegates[idx].name == targetTimegate.name)
            {
                UCE_TimeGate myTimegate = new UCE_TimeGate();
                myTimegate.name = targetTimegate.name;
                myTimegate.count = UCE_timegates[idx].count + 1;
                myTimegate.hours = DateTime.UtcNow.ToString("s");
                myTimegate.valid = true;
                UCE_timegates[idx] = myTimegate;
                done = true;
            }
            // -- Add new Timegate if it does not exist
            if (!done)
            {
                UCE_TimeGate myTimegate = new UCE_TimeGate();
                myTimegate.name = targetTimegate.name;
                myTimegate.count = 1;
                myTimegate.hours = DateTime.UtcNow.ToString("s");
                myTimegate.valid = true;
                UCE_timegates.Add(myTimegate);
            }
        }
    }

    // -----------------------------------------------------------------------------------
}
