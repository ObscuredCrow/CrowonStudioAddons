// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UCE/Item/Taming", order = 0)]
public class UCE_ItemTaming : UsableItem
{
    public float successIncrease = 0.0f;
    public bool deleteItemAfter = true;

    // Start is called before the first frame update
    public override void Use(Player player, int inventoryIndex)
    {
        if (player.isTaming) return;
        if (player.target == null) return;
        if (player.target.state == "DEAD") return;
        Monster monster = (Monster)player.target;
        if (monster != null)
        {
            if (monster.tamingReward.item != null)
            {
                player.CmdSetupTamingSuccessRate(successIncrease);
                player.StartCoroutine(player.TamingTask());
            }
        }
        if (!deleteItemAfter) return;
        // decrease amount
        ItemSlot slot = player.inventory[inventoryIndex];
        slot.DecreaseAmount(1);
        player.inventory[inventoryIndex] = slot;
    }
}