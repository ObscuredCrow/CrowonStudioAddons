// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

#if _CSLOOTRULES && _CSITEMDROP

// ===================================================================================
// LOOT RULES - PLAYER
// ===================================================================================
public partial class Player
{
    [Header("[-=-=- UCE ITEM DROP & LOOT RULES -=-=-]")]
    public UCE_PlayerLootRules lootRules;

    // -----------------------------------------------------------------------------------
    // Update_UCE_LootRules
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    public void Update_UCE_LootRules()
    {
        if (lootRules.LiftRulesAfter > 0 && NetworkTime.time > lootRules.deathTime + lootRules.LiftRulesAfter)
            lootRules.lootRulesLifted = true;
        else
            lootRules.lootRulesLifted = false;
    }

    // -----------------------------------------------------------------------------------
    // OnDeath_UCE_LootRules
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    [DevExtMethods("OnDeath")]
    private void OnDeath_UCE_LootRules()
    {
        lootRules.deathTime = NetworkTime.time;

        // ---------------------------------------------------------------------- Equipment

        for (int i = 0; i < equipment.Count; ++i)
        {
            int idx = i;
            ItemSlot itemSlot = equipment[i];

            if (itemSlot.amount > 0 && Random.value <= itemSlot.item.data.dropChance + lootRules.equipmentDropModifier)
            {
                Vector3 position = UCE_Tools.ReachableRandomUnitCircleOnNavMesh(transform.position, lootRules.radiusMultiplier, lootRules.dropSolverAttempts);

                GameObject drop = Instantiate(itemSlot.item.data.dropPrefab.gameObject, position, Quaternion.identity);

                drop.GetComponent<UCE_ItemDrop>().itemData = itemSlot.item.data;
                drop.GetComponent<UCE_ItemDrop>().amount = itemSlot.amount;
                drop.GetComponent<UCE_ItemDrop>().item = new Item(itemSlot.item.data);

#if _CSLOOTRULES && _CSITEMDROP

                drop.GetComponent<UCE_ItemDrop>().LiftRulesAfter = lootRules.LiftRulesAfter;
                drop.GetComponent<UCE_ItemDrop>().LootVictorParty = lootRules.LootVictorParty;
                drop.GetComponent<UCE_ItemDrop>().LootVictorGuild = lootRules.LootVictorGuild;
#if _CSPVPREALMS
                drop.GetComponent<UCE_ItemDrop>().LootVictorRealm = lootRules.LootVictorRealm;
                drop.GetComponent<UCE_ItemDrop>().hashRealm = hashRealm;
                drop.GetComponent<UCE_ItemDrop>().hashAlly = hashAlly;
#endif
                drop.GetComponent<UCE_ItemDrop>().LootEverybody = lootRules.LootEverybody;

                drop.GetComponent<UCE_ItemDrop>().lastAggressor = this.lastAggressor;
                drop.GetComponent<UCE_ItemDrop>().owner = this;
#endif

                itemSlot.amount = 0;
                equipment[idx] = itemSlot;

                NetworkServer.Spawn(drop);
            }
        }

        // ---------------------------------------------------------------------- Gold
        if (lootRules.goldDropPrefab != null && gold > 0)
        {
            Vector3 position = UCE_Tools.ReachableRandomUnitCircleOnNavMesh(transform.position, lootRules.radiusMultiplier, lootRules.dropSolverAttempts);

            GameObject drop = Instantiate(lootRules.goldDropPrefab.gameObject, position, Quaternion.identity);

            drop.GetComponent<UCE_ItemDrop>().amount = 0;
            int droppedGold = (int)(gold * lootRules.goldPercentage);
            drop.GetComponent<UCE_ItemDrop>().gold = droppedGold;
            gold -= droppedGold;

#if _CSLOOTRULES && _CSITEMDROP
            drop.GetComponent<UCE_ItemDrop>().LiftRulesAfter = lootRules.LiftRulesAfter;
            drop.GetComponent<UCE_ItemDrop>().LootVictorParty = lootRules.LootVictorParty;
            drop.GetComponent<UCE_ItemDrop>().LootVictorGuild = lootRules.LootVictorGuild;
#if _CSPVPREALMS
            drop.GetComponent<UCE_ItemDrop>().LootVictorRealm = lootRules.LootVictorRealm;
            drop.GetComponent<UCE_ItemDrop>().hashRealm = hashRealm;
            drop.GetComponent<UCE_ItemDrop>().hashAlly = hashAlly;
#endif
            drop.GetComponent<UCE_ItemDrop>().LootEverybody = lootRules.LootEverybody;
            drop.GetComponent<UCE_ItemDrop>().lastAggressor = this.lastAggressor;
            drop.GetComponent<UCE_ItemDrop>().owner = this;
#endif
            NetworkServer.Spawn(drop);
        }
        else if (lootRules.goldDropPrefab == null && gold > 0)
        {
            Debug.LogWarning("You forgot to assign a gold drop to: " + this.name);
        }

        // ---------------------------------------------------------------------- Inventory

        for (int i = 0; i < inventory.Count; ++i)
        {
            int idx = i;
            ItemSlot itemSlot = inventory[i];

            if (itemSlot.amount > 0 && Random.value <= itemSlot.item.data.dropChance + lootRules.inventoryDropModifier)
            {
                if (itemSlot.item.data.dropPrefab == null)
                {
                    Debug.LogWarning("You forgot to assign a item drop to: " + itemSlot.item.name);
                    continue;
                }

                Vector3 position = UCE_Tools.ReachableRandomUnitCircleOnNavMesh(transform.position, lootRules.radiusMultiplier, lootRules.dropSolverAttempts);

                GameObject drop = Instantiate(itemSlot.item.data.dropPrefab.gameObject, position, Quaternion.identity);

                drop.GetComponent<UCE_ItemDrop>().itemData = itemSlot.item.data;
                drop.GetComponent<UCE_ItemDrop>().amount = itemSlot.amount;
                drop.GetComponent<UCE_ItemDrop>().item = new Item(itemSlot.item.data);

#if _CSLOOTRULES && _CSITEMDROP

                drop.GetComponent<UCE_ItemDrop>().LiftRulesAfter = lootRules.LiftRulesAfter;
                drop.GetComponent<UCE_ItemDrop>().LootVictorParty = lootRules.LootVictorParty;
                drop.GetComponent<UCE_ItemDrop>().LootVictorGuild = lootRules.LootVictorGuild;
#if _CSPVPREALMS
                drop.GetComponent<UCE_ItemDrop>().LootVictorRealm = lootRules.LootVictorRealm;
                drop.GetComponent<UCE_ItemDrop>().hashRealm = hashRealm;
                drop.GetComponent<UCE_ItemDrop>().hashAlly = hashAlly;
#endif
                drop.GetComponent<UCE_ItemDrop>().LootEverybody = lootRules.LootEverybody;

                drop.GetComponent<UCE_ItemDrop>().lastAggressor = this.lastAggressor;
                drop.GetComponent<UCE_ItemDrop>().owner = this;

#endif

                itemSlot.amount = 0;
                inventory[idx] = itemSlot;

                NetworkServer.Spawn(drop);
            }
        }
    }

    // -----------------------------------------------------------------------------------
    // UCE_ValidateTaggedLooting
    // -----------------------------------------------------------------------------------
    public bool UCE_ValidateTaggedLooting(Player player)
    {
        if (lootRules.LootEverybody ||
        lastAggressor == null ||
        lastAggressor == player ||
        (lootRules.LiftRulesAfter > 0 && NetworkTime.time > lootRules.deathTime + lootRules.LiftRulesAfter)
        ) return true;
        if (lootRules.LootVictorParty && UCE_ValidateTaggedLootingParty(player)) return true;
        if (lootRules.LootVictorGuild && UCE_ValidateTaggedLootingGuild(player)) return true;
#if _CSPVPREALMS
        if (lootRules.LootVictorRealm && UCE_ValidateTaggedLootingRealm(player)) return true;
#endif
        return false;
    }

    // -----------------------------------------------------------------------------------
}

#endif