// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// ENTITY

public partial class Entity
{
    [HideInInspector] public UCE_Area_WaveSpawner UCE_parentSpawnArea;
    [HideInInspector] public int UCE_parentWaveIndex;

    // -----------------------------------------------------------------------------------
    // OnDeath
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnDeath")]
    private void OnDeath_UCE_WaveSpawnerEntity()
    {
        if (UCE_parentSpawnArea == null) return;
        UCE_parentSpawnArea.updateMemberPopulation(name.GetDeterministicHashCode(), UCE_parentWaveIndex);
        UCE_parentSpawnArea = null;
    }

    // -----------------------------------------------------------------------------------
}