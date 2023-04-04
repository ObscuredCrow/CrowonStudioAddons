// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// CONVERT ITEM

[CreateAssetMenu(menuName = "UCE/Item/Convert", order = 0)]
public class UCE_ItemConvert : UsableItem
{
    [Header("[-=-=-=- UCE Convert Item -=-=-=-]")]
    [Range(0, 1)] public float successChance;

    public float range;

    [Tooltip("[Optional] Maximum level of the target (0 to disable)")]
    public int maxTargetLevel;

    [Tooltip("[Optional] Uses player level as a base to calculate max Level of monster")]
    public bool basePlayerLevel;

    public string tauntMessage = "You converted: ";
    public string failedMessage = "You failed to convert: ";

    [Tooltip("[Optional] Decrease amount by how many each use (can be 0)?")]
    public int decreaseAmount = 1;

    // -----------------------------------------------------------------------------------
    // CheckTarget
    // -----------------------------------------------------------------------------------
    public bool CheckTarget(Entity caster)
    {
        return caster.target != null && caster.CanAttack(caster.target);
    }

    // -----------------------------------------------------------------------------------
    // CheckDistance
    // -----------------------------------------------------------------------------------
    public bool CheckDistance(Entity caster, int skillLevel, out Vector3 destination)
    {
        if (caster.target != null)
        {
            destination = caster.target.collider.ClosestPointOnBounds(caster.transform.position);
            return Utils.ClosestDistance(caster, caster.target) <= range;
        }
        destination = caster.transform.position;
        return false;
    }

    // -----------------------------------------------------------------------------------
    // Use
    // -----------------------------------------------------------------------------------
    public override void Use(Player player, int inventoryIndex)
    {
#if _CSPVPREALMS
        ItemSlot slot = player.inventory[inventoryIndex];

        // -- Only activate if enough charges left
        if (decreaseAmount == 0 || slot.amount >= decreaseAmount)
        {
            if (player.target != null && player.target is Monster)
            {
                // always call base function too
                base.Use(player, inventoryIndex);

                int maxLevel = maxTargetLevel;

                if (basePlayerLevel)
                    maxLevel += player.level;

                Monster monster = player.target.GetComponent<Monster>();

                if (monster.level <= maxLevel && UnityEngine.Random.value <= successChance)
                {
                    monster.UCE_setRealm(player.hashRealm, player.hashAlly);
                    player.UCE_TargetAddMessage(tauntMessage + monster.name);
                }
                else
                {
                    player.UCE_TargetAddMessage(failedMessage + monster.name);
                }

                // decrease amount
                slot.DecreaseAmount(decreaseAmount);
                player.inventory[inventoryIndex] = slot;
            }
        }
#endif
    }
}