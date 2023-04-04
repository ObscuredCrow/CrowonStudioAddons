// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

#if UNITY_EDITOR

using UnityEditor;

#endif

// ConfigurationManager

public partial class ConfigurationManager : MonoBehaviour
{
    [Header("Configuration")]
    public UCE_TemplateConfiguration configTemplate;

    [Header("Defines")]
    public UCE_TemplateDefines addonTemplate;

    [Header("Game Rules")]
    public UCE_TemplateGameRules rulesTemplate;

    // -----------------------------------------------------------------------------------
    //
    // -----------------------------------------------------------------------------------
    private void OnValidate()
    {
    }

    // -----------------------------------------------------------------------------------
    //
    // -----------------------------------------------------------------------------------

    // -----------------------------------------------------------------------------------
}