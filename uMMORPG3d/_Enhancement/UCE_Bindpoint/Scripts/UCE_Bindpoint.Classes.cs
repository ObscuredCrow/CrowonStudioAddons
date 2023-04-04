// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE_BindPoint

[System.Serializable]
public struct UCE_BindPoint
{
    public string name;
    public string SceneName;
    public Vector3 position;

    public UnityScene mapScene
    {
        set { SceneName = value.SceneName; }
    }

    public bool Valid
    {
        get
        {
            return !string.IsNullOrEmpty(SceneName);
        }
    }
}