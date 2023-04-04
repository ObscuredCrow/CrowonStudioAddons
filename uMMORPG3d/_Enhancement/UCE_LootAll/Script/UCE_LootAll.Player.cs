// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class Player
{
    public void TakeAllLootItem()
    {
        CmdTakeLootGold();
        var items = target.inventory.Where(item => item.amount > 0).ToList();
        if(items.Count > 0)
            for (int i = 0; i < items.Count; ++i)
            {
                int itemIndex = target.inventory.FindIndex(item => item.amount > 0 && item.item.name == items[i].item.name);
                CmdTakeLootItem(itemIndex);
            }
    }
}