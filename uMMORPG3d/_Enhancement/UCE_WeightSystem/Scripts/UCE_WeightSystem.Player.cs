// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using System.Linq;
using UnityEngine;

// PLAYER

public partial class Player
{
    [Header("[-=-=- UCE WEIGHT SYSTEM -=-=-]")]
    public UCE_WeightSystem weightSystem;

    protected int totalWeight;
    protected int maxWeight;
    protected float _updateTimer;

    // -----------------------------------------------------------------------------------
    // Update_UCE_WeightSystem
    // @Server
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    [DevExtMethods("Update")]
    private void Update_UCE_WeightSystem()
    {
        if (weightSystem.burdenedBuff == null || !isServer) return;

        // -- Delayed Update (once per second instead of once per frame)

        if (Time.time > _updateTimer)
        {
            // -- calculate weight
            UCE_CalculateWeight();

            if (totalWeight <= 0) return;

            // -- check burdened
            int burdenLevel = UCE_IsBurdened();

            // -- apply or remove burdened
            if (burdenLevel > 0)
            {
                AddOrRefreshBuff(new Buff(weightSystem.burdenedBuff, burdenLevel));
            }
            else
            {
                UCE_RemoveBuff(weightSystem.burdenedBuff);
            }

            _updateTimer = Time.time + cacheTimerInterval;
        }
    }

    // -----------------------------------------------------------------------------------
    // UCE_CalculateWeight
    // -----------------------------------------------------------------------------------
    protected void UCE_CalculateWeight()
    {
        totalWeight = 0;

#if _CSATTRIBUTES
        if (weightSystem.weightAttribute != null)
        {
            UCE_Attribute attrib = UCE_Attributes.FirstOrDefault(x => x.template == weightSystem.weightAttribute);
            maxWeight = weightSystem.carryPerPoint + ((attrib.points + UCE_calculateBonusAttribute(attrib)) * weightSystem.carryPerPoint);
        }
#else
        maxWeight = weightSystem.maxCarryWeight;
#endif

        for (int i = 0; i < inventory.Count; ++i)
        {
            ItemSlot slot = inventory[i];
            if (slot.amount > 0)
                totalWeight += slot.item.data.weight * slot.amount;
        }

        for (int i = 0; i < equipment.Count; ++i)
        {
            ItemSlot slot = equipment[i];
            if (slot.amount > 0)
                totalWeight += slot.item.data.weight * slot.amount;
        }
    }

    // -----------------------------------------------------------------------------------
    // UCE_IsBurdened
    // -----------------------------------------------------------------------------------
    protected int UCE_IsBurdened()
    {
        if (totalWeight <= maxWeight)
        {
            return 0;
        }
        else
        {
            return Mathf.Min((int)totalWeight / maxWeight, weightSystem.maxBurdenLevel);
        }
    }

    // -----------------------------------------------------------------------------------
}