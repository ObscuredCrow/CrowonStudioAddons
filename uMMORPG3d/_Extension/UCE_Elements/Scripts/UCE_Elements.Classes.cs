// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// UCE ELEMENT MODIFIER

[System.Serializable]
public class UCE_ElementModifier
{
    public UCE_ElementTemplate template;
    public float value = 1f;
}

// UCE ELEMENT CACHE

[System.Serializable]
public class UCE_ElementCache
{
    public float timer = 0f;
    public float value = 0f;
}