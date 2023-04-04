// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// HAZARD BUFF

[System.Serializable]
public class UCE_HazardBuff
{
    public TargetBuffSkill buff;
    public int minBuffLevel;
    public int maxBuffLevel;
    public float chance = 1f;
    public string protectiveMessage = "You are protected against the Hazard Floor effects!";
    public UCE_ActivationRequirements protectiveRequirements;
}