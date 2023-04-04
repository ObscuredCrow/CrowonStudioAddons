// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// ENTITY

public partial class Entity
{
    [Header("[-=-=- UCE TOMBSTONE -=-=-]")]
    public UCE_Tombstone tombstone;

    // -----------------------------------------------------------------------------------
    // OnDeath_UCE_Tombstone
    // ----------------------------------------------------------------------------------
    [DevExtMethods("OnDeath")]
    private void OnDeath_UCE_Tombstone()
    {
        if (tombstone.tombstone == null || tombstone.tombstone.Length <= 0 || tombstone.tombstoneChance <= 0) return;

        foreach (GameObject gob in tombstone.tombstone)
        {
            if (UnityEngine.Random.value <= tombstone.tombstoneChance)
            {
                Vector3 v = new Vector3(transform.position.x, transform.position.y + tombstone.tombstoneFallHeight, transform.position.z);
                GameObject go = Instantiate(gob, v, transform.rotation);
                NetworkServer.Spawn(go);
            }
        }
    }

    // -----------------------------------------------------------------------------------
}