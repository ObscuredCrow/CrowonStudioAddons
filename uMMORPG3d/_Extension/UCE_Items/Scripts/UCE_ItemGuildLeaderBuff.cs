// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE SKILL PARTY LEADER BUFF

[CreateAssetMenu(menuName = "UCE/Item/Guild Leader Buff", order = 0)]
public class UCE_ItemGuildLeaderBuff : UsableItem
{
    [Header("-=-=-=- Buff Guild Members -=-=-=-")]
    public BuffSkill applyBuff;

    public int skillLevel;

    [Tooltip("Decrease amount by how many each use (can be 0)?")]
    public int decreaseAmount = 1;

    // -----------------------------------------------------------------------------------
    // Apply
    // -----------------------------------------------------------------------------------
    public override void Use(Player player, int inventoryIndex)
    {
        ItemSlot slot = player.inventory[inventoryIndex];

        // -- Only activate if enough charges left
        if (decreaseAmount == 0 || slot.amount >= decreaseAmount)
        {
            if (player.InGuild())
            {
                // always call base function too
                base.Use(player, inventoryIndex);

                foreach (GuildMember member in (player.guild.members))
                {
                    if (Player.onlinePlayers.ContainsKey(member.name))
                    {
                        Player plyr = Player.onlinePlayers[member.name];
                        if (plyr.isAlive)
                        {
                            plyr.UCE_ApplyBuff(applyBuff, skillLevel, 1);
                        }
                    }
                }

                // decrease amount
                slot.DecreaseAmount(decreaseAmount);
                player.inventory[inventoryIndex] = slot;
            }
        }
    }

    // -----------------------------------------------------------------------------------
}