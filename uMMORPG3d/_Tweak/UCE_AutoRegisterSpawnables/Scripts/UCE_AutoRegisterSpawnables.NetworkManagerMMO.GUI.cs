// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using System.Collections;
using UnityEditor;

#if UNITY_EDITOR

[CustomEditor(typeof(NetworkManagerMMO))]
public class LevelScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        NetworkManagerMMO mNetwork = (NetworkManagerMMO)target;
        if (GUILayout.Button("Search and add network prefabs"))
        {
            mNetwork.AutoRegisterSpawnables();
        }
    }
}

#endif