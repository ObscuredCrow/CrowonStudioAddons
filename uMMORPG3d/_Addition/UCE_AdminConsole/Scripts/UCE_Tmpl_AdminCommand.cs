// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if _CSASSETBUNDLEMANAGER
using Jacovone.AssetBundleMagic;
#endif

// ADMIN COMMAND - TEMPLATE

[CreateAssetMenu(fileName = "UCE AdminCommand", menuName = "UCE/Template/Admin Command", order = 0)]
public class UCE_Tmpl_AdminCommand : ScriptableObject
{
    [Header("-=-=-=- UCE Admin Command -=-=-=-")]
    public string commandName;

    public string functionName;
    [Range(1, 100)] public int commandLevel;
    public UCE_AdminCommandArgument[] arguments;
    public string helpText;

    // -----------------------------------------------------------------------------------
    // getFormat
    // -----------------------------------------------------------------------------------
    public string getFormat()
    {
        string format = "";

        format += commandName + " ";

        foreach (UCE_AdminCommandArgument arg in arguments)
        {
            format += "<" + arg.argumentType.ToString() + "> ";
        }

        return format;
    }

    // -----------------------------------------------------------------------------------
    // Caching
    // -----------------------------------------------------------------------------------
    private static Dictionary<int, UCE_Tmpl_AdminCommand> _cache;

    public static Dictionary<int, UCE_Tmpl_AdminCommand> dict
    {
        get
        {
            if (_cache == null)
            {
                UCE_ScripableObjectEntry entry = UCE_TemplateConfiguration.singleton.GetEntry(typeof(UCE_Tmpl_AdminCommand));
                string folderName = entry != null ? entry.folderName : "";
#if _CSASSETBUNDLEMANAGER
                if (entry != null && entry.loadFromAssetBundle)
                    _cache = AssetBundleMagic.LoadBundle(entry.bundleName).LoadAllAssets<UCE_Tmpl_AdminCommand>().ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
                else
                    _cache = Resources.LoadAll<UCE_Tmpl_AdminCommand>(folderName).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#else
                _cache = Resources.LoadAll<UCE_Tmpl_AdminCommand>(UCE_TemplateConfiguration.singleton.GetTemplatePath(typeof(UCE_Tmpl_AdminCommand))).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#endif
            }

            return _cache;
        }
    }

    // -----------------------------------------------------------------------------------
}