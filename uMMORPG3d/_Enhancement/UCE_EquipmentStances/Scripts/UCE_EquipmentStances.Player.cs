// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Linq;
using UnityEngine;

// PLAYER

public partial class Player
{
    [Header("-=-=-=- UCE Equipment Stances -=-=-=-")]
    public string[] equipmentStances;

    // -----------------------------------------------------------------------------------
    //
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnStartLocalPlayer")]
    private void OnStartLocalPlayer_UCE_EquipmentStances()
    {
        OnEquipmentChanged_UCE_EquipmentStances();
    }

    // -----------------------------------------------------------------------------------
    // UCE_RefreshStance
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnEquipmentChanged")]
    private void OnEquipmentChanged_UCE_EquipmentStances()
    {
        foreach (Animator anim in GetComponentsInChildren<Animator>())
            foreach (string stance in equipmentStances)
                anim.SetBool(stance, false);

        for (int i = 0; i < equipment.Count; ++i)
        {
            ItemSlot slot = equipment[i];

            if (slot.amount > 0)
            {
                EquipmentItem itemData = (EquipmentItem)slot.item.data;

                if (itemData != null && itemData.category != "" && equipmentStances.Contains(itemData.category))
                {
                    foreach (Animator anim in GetComponentsInChildren<Animator>())
                        anim.SetBool(itemData.category, true);
                }
            }
        }
    }

    // -----------------------------------------------------------------------------------
}