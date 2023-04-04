// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// ===================================================================================
// ITEM DROP - MONSTER
// ===================================================================================
public partial class Monster
{
    [Header("[-=-=- UCE ITEM DROP -=-=-]")]
    public float radiusMultiplier = 2;

    protected int dropSolverAttempts = 3; // attempts to drop without being behind a wall, etc.

    [Tooltip("[Required] Drop prefab used for gold drops")]
    public UCE_ItemDrop goldDropPrefab;

    // -----------------------------------------------------------------------------------
    // OnDeath_UCE_ItemDrop
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    [DevExtMethods("OnDeath")]
    private void OnDeath_UCE_ItemDrop()
    {
        // ---------- drop gold
        if (goldDropPrefab != null && gold > 0)
        {
            Vector3 position = UCE_Tools.ReachableRandomUnitCircleOnNavMesh(transform.position, radiusMultiplier, dropSolverAttempts);

            GameObject drop = Instantiate(goldDropPrefab.gameObject, position, Quaternion.identity);

            drop.GetComponent<UCE_ItemDrop>().amount = 0;
            drop.GetComponent<UCE_ItemDrop>().gold = gold;
            gold = 0;

#if _CSLOOTRULES && _CSITEMDROP
            drop.GetComponent<UCE_ItemDrop>().LiftRulesAfter = LiftRulesAfter;
            drop.GetComponent<UCE_ItemDrop>().LootVictorParty = LootVictorParty;
            drop.GetComponent<UCE_ItemDrop>().LootVictorGuild = LootVictorGuild;
#if _CSPVPREALMS
            drop.GetComponent<UCE_ItemDrop>().LootVictorRealm = LootVictorRealm;
            drop.GetComponent<UCE_ItemDrop>().hashRealm = hashRealm;
            drop.GetComponent<UCE_ItemDrop>().hashAlly = hashAlly;
#endif
            drop.GetComponent<UCE_ItemDrop>().LootEverybody = LootEverybody;
            drop.GetComponent<UCE_ItemDrop>().lastAggressor = this.lastAggressor;
            drop.GetComponent<UCE_ItemDrop>().owner = this;
#endif
            NetworkServer.Spawn(drop);
        }
        else if (goldDropPrefab == null && gold > 0)
        {
            Debug.LogWarning("You forgot to assign a gold drop to: " + this.name);
        }

        // ---------- drop items
        foreach (ItemSlot itemSlot in inventory)
        {
            if (itemSlot.amount > 0)
            {
                if (itemSlot.item.data.dropPrefab == null)
                {
                    Debug.LogWarning("You forgot to assign a item drop to: " + itemSlot.item.name);
                    continue;
                }

                Vector3 position = UCE_Tools.ReachableRandomUnitCircleOnNavMesh(transform.position, radiusMultiplier, dropSolverAttempts);

                GameObject drop = Instantiate(itemSlot.item.data.dropPrefab.gameObject, position, Quaternion.identity);

                drop.GetComponent<UCE_ItemDrop>().itemData = itemSlot.item.data;
                drop.GetComponent<UCE_ItemDrop>().amount = itemSlot.amount;
                drop.GetComponent<UCE_ItemDrop>().gold = 0;
                drop.GetComponent<UCE_ItemDrop>().item = new Item(itemSlot.item.data);

#if _CSLOOTRULES && _CSITEMDROP
                drop.GetComponent<UCE_ItemDrop>().LiftRulesAfter = LiftRulesAfter;
                drop.GetComponent<UCE_ItemDrop>().LootVictorParty = LootVictorParty;
                drop.GetComponent<UCE_ItemDrop>().LootVictorGuild = LootVictorGuild;
#if _CSPVPREALMS
                drop.GetComponent<UCE_ItemDrop>().LootVictorRealm = LootVictorRealm;
                drop.GetComponent<UCE_ItemDrop>().hashRealm = hashRealm;
                drop.GetComponent<UCE_ItemDrop>().hashAlly = hashAlly;
#endif
                drop.GetComponent<UCE_ItemDrop>().LootEverybody = LootEverybody;
                drop.GetComponent<UCE_ItemDrop>().lastAggressor = this.lastAggressor;
                drop.GetComponent<UCE_ItemDrop>().owner = this;
#endif

                NetworkServer.Spawn(drop);
            }
        }

        inventory.Clear();
    }

    // -----------------------------------------------------------------------------------
}