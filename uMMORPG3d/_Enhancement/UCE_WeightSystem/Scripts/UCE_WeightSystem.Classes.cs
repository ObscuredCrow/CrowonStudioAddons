// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// UCE WEIGHT SYSTEM

[System.Serializable]
public partial class UCE_WeightSystem
{
    public TargetBuffSkill burdenedBuff;
#if _CSATTRIBUTES
    public UCE_AttributeTemplate weightAttribute;
    public int carryPerPoint;
#else
    public int maxCarryWeight;
#endif
    public int maxBurdenLevel;
}