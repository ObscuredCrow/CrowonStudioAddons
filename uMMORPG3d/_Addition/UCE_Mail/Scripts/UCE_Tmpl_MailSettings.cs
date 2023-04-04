// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// PLAYER MAIL SETTINGS

[CreateAssetMenu(fileName = "UCE Mail Settings", menuName = "UCE/Template/Mail Settings", order = 0)]
public class UCE_Tmpl_MailSettings : ScriptableObject
{
    [Header("[EXPIRATION]")]
    [Range(1, 999)] public int expiresAmount = 30;

    public DateInterval expiresPart = DateInterval.Days;

    [Header("[SEND]")]
    public bool mailSendFromAnywhere = true;

    [Range(0, 99)] public int mailWaitSeconds = 3;
    public UCE_Cost costPerMail;

    [Header("[RECEIVE]")]
    [Range(1, 999)] public int mailCheckSeconds = 30;

    [Header("[LABELS]")]
    public string labelRecipient;

    public string labelSubject;
    public string labelBody;
    public string labelCost;
}