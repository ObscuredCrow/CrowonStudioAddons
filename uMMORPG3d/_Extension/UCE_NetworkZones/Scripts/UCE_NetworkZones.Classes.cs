// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Mirror;

// SceneLocation

[System.Serializable]
public partial class SceneLocation
{
    public UnityScene mapScene;
    public Vector3 position;

    public bool Valid
    {
        get
        {
            return mapScene.IsSet();
        }
    }
}