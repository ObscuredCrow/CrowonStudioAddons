// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// FRIENDLIST

[CreateAssetMenu(fileName = "UCE Friendship", menuName = "UCE/Template/Friendship", order = 0)]
public class UCE_Tmpl_Friendship : ScriptableObject
{
    public int maxFriends = 50;

#if _CSHONORSHOP

    [Tooltip("The type of Honor Currency the player who hugs will get")]
    public UCE_Tmpl_HonorCurrency honorCurrency;

    [Tooltip("How much Honor Currency the hugging player gets")]
    public long amount;

    [Tooltip("The Honor Currency the hugged player gets (only when online!)")]
    public UCE_Tmpl_HonorCurrency friendHonorCurrency;

    [Tooltip("The amount of Honor Currency the hugged player receives")]
    public long friendAmount;

    [Tooltip("How many hours must pass between hugs?")]
    public int timespanHours;

#endif

    public string msgMaxFriends = "You cannot have anymore friends!";
    public string msgIsNowFriend = "{0} is now your friend.";
    public string msgIsAlreadyFriend = "{0} is already your friend";
    public string msgCannotFriendSelf = "You cannot add yourself as a friend.";
    public string msgTargetOffline = "{0} is not online.";
    public string msgTargetNotExist = "A player {0} does not exist.";
    public string msgNoLongerFriend = "{0} is no longer your friend.";
    public string msgTargetNotFriend = "{0} is not your friend.";
    public string msgTargetHugged = "You hugged {0} and gained {1} {2}.";
}