// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections.Generic;
using System.Linq;

// PLAYER

public partial class Player
{
    protected List<TargetBuffSkill> equipmentBuffs = new List<TargetBuffSkill>();

    // -----------------------------------------------------------------------------------
    // OnStartLocalPlayer_UCE_EquipableBuff
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnStartLocalPlayer")]
    private void OnStartLocalPlayer_UCE_EquipableBuff()
    {
        equipmentBuffs = new List<TargetBuffSkill>();
        OnEquipmentChanged_UCE_EquipableBuff();
    }

    // -----------------------------------------------------------------------------------
    // DealDamageAt_UCE_EquipableBuff
    // -----------------------------------------------------------------------------------
    [DevExtMethods("DealDamageAt")]
    private void DealDamageAt_UCE_EquipableBuff(Entity entity, int amount)
    {
        if (entity == null || amount <= 0) return;

        for (int i = 0; i < equipment.Count; ++i)
        {
            ItemSlot slot = equipment[i];

            if (slot.amount > 0)
            {
                EquipmentItem itemData = (EquipmentItem)slot.item.data;

                if (itemData != null && itemData.onAttackBuff != null && itemData.onAttackBuffApplyChance > 0)
                    itemData.ApplyOnAttackBuffTarget(this, entity);
            }
        }
    }

    // -----------------------------------------------------------------------------------
    // OnDamageDealt_UCE_EquipableBuff
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnDamageDealt")]
    private void OnDamageDealt_UCE_EquipableBuff()
    {
        for (int i = 0; i < equipment.Count; ++i)
        {
            ItemSlot slot = equipment[i];

            if (slot.amount > 0)
            {
                EquipmentItem itemData = (EquipmentItem)slot.item.data;

                if (itemData != null && itemData.onHitBuffSelf != null && itemData.onHitBuffSelfApplyChance > 0)
                    itemData.ApplyOnHitBuffSelf(this);
            }
        }
    }

    // -----------------------------------------------------------------------------------
    // OnEquipmentChanged_UCE_EquipableBuff
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnEquipmentChanged")]
    private void OnEquipmentChanged_UCE_EquipableBuff()
    {
        // -- remove buffs

        for (int i = 0; i < buffs.Count; ++i)
        {
            if (equipmentBuffs.Any(x => x == buffs[i].data))
            {
                buffs.RemoveAt(i);
                --i;
            }
        }

        // -- clear list

        equipmentBuffs.Clear();

        // -- apply buffs & add to list again

        for (int i = 0; i < equipment.Count; ++i)
        {
            ItemSlot slot = equipment[i];

            if (slot.amount > 0)
            {
                EquipmentItem itemData = (EquipmentItem)slot.item.data;

                if (itemData != null && itemData.onEquipBuffSelf != null)
                {
                    itemData.ApplyEquipableBuff(this);
                    equipmentBuffs.Add(itemData.onEquipBuffSelf);
                }
            }
        }
    }

    // -----------------------------------------------------------------------------------
}