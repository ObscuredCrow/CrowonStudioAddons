// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

#if UNITY_EDITOR

using UnityEditor;

#endif

// TemplateDefines

[CreateAssetMenu(menuName = "UCE/Other/Defines", fileName = "UCE_Defines", order = 0)]
public partial class UCE_TemplateDefines : ScriptableObject
{
    private static UCE_TemplateDefines _instance;
#if UNITY_EDITOR

    [SerializeField]
    [Header("(Change list size to force refresh)")]
    public List<UCE_AddOn> addons = new List<UCE_AddOn>();

#endif

    // -----------------------------------------------------------------------------------
    // OnValidate
    // -----------------------------------------------------------------------------------
    private void OnValidate()
    {
#if UNITY_EDITOR

        if (UCE_DefinesManager.addons.Count() > 0 && addons.Count() != UCE_DefinesManager.addons.Count() - 1)
        {
            addons.Clear();

            for (int i = 0; i < UCE_DefinesManager.addons.Count(); ++i)
            {
                UCE_AddOn addon = new UCE_AddOn();
                addon.Copy(UCE_DefinesManager.addons[i]);

                if (addon.define != "_CSTOOLS" && addon.define != "_CSCORE")
                    addons.Add(addon);
                else
                    UCE_EditorTools.AddScriptingDefine(addon.define);
            }
        }

        UpdateDefines();

#endif
    }

    // -----------------------------------------------------------------------------------
    // UpdateDefines
    // -----------------------------------------------------------------------------------
    public void UpdateDefines()
    {
#if UNITY_EDITOR
        for (int i = 0; i < addons.Count(); ++i)
        {
            if (addons[i].define == "_CSTOOLS" && addons[i].define == "_CSCORE") continue;

            if (!addons[i].active)
                UCE_EditorTools.RemoveScriptingDefine(addons[i].define);
            else
                UCE_EditorTools.AddScriptingDefine(addons[i].define);
        }
#endif
    }

    // -----------------------------------------------------------------------------------
    // Singleton
    // -----------------------------------------------------------------------------------
    public static UCE_TemplateDefines singleton
    {
        get
        {
            if (!_instance)
                _instance = Resources.FindObjectsOfTypeAll<UCE_TemplateDefines>().FirstOrDefault();
            return _instance;
        }
    }

    // -----------------------------------------------------------------------------------
}