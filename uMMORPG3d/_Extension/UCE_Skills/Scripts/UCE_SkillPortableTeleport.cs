// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// SKILL DEBUFF

[CreateAssetMenu(menuName = "UCE/Skill/Portable Teleport", order = 0)]
public class UCE_SkillPortableTeleport : ScriptableSkill
{
    [Header("-=-=-=- UCE Skill Portable Teleport -=-=-=-")]
    [Tooltip("[Required] GameObject prefab with coordinates OR off scene coordinates (requires UCE Network Zones AddOn)")]
    public UCE_TeleportationTarget teleportationTarget;

    [Tooltip("This will ignore the teleport Location and choose the nearest spawn point instead")]
    public bool teleportToClosestSpawnpoint;

    // -----------------------------------------------------------------------------------
    //
    // -----------------------------------------------------------------------------------
    public override bool CheckTarget(Entity caster)
    {
        return true;
    }

    // -----------------------------------------------------------------------------------
    //
    // -----------------------------------------------------------------------------------
    public override bool CheckDistance(Entity caster, int skillLevel, out Vector3 destination)
    {
        destination = caster.transform.position;
        return true;
    }

    // -----------------------------------------------------------------------------------
    //
    // -----------------------------------------------------------------------------------
    public override void Apply(Entity caster, int skillLevel)
    {
        // apply only to alive people
        if (caster.isAlive)
        {
            // -- Determine Teleportation Target
            if (teleportToClosestSpawnpoint)
            {
                Transform target = NetworkManagerMMO.GetNearestStartPosition(caster.transform.position);
                ((Player)caster).UCE_Warp(target.position);
            }
            else
            {
                teleportationTarget.OnTeleport((Player)caster);
            }
        }
    }

    // -----------------------------------------------------------------------------------
}