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

// UCE WORLD EVENT

[CreateAssetMenu(fileName = "New UCE WorldEvent", menuName = "UCE/Template/World Event", order = 0)]
public partial class UCE_WorldEventTemplate : ScriptableObject
{
    [Header("[EVENT THRESHOLDS (checked top to bottom)]")]
    public UCE_WorldEventData[] thresholdData;

    // -----------------------------------------------------------------------------------
    // Caching
    // -----------------------------------------------------------------------------------
    private static Dictionary<int, UCE_WorldEventTemplate> _cache;

    public static Dictionary<int, UCE_WorldEventTemplate> dict
    {
        get
        {
            if (_cache == null)
            {
                UCE_ScripableObjectEntry entry = UCE_TemplateConfiguration.singleton.GetEntry(typeof(UCE_WorldEventTemplate));
                string folderName = entry != null ? entry.folderName : "";
#if _CSASSETBUNDLEMANAGER
                if (entry != null && entry.loadFromAssetBundle)
                    _cache = AssetBundleMagic.LoadBundle(entry.bundleName).LoadAllAssets<UCE_WorldEventTemplate>().ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
                else
                    _cache = Resources.LoadAll<UCE_WorldEventTemplate>(folderName).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#else
                _cache = Resources.LoadAll<UCE_WorldEventTemplate>(UCE_TemplateConfiguration.singleton.GetTemplatePath(typeof(UCE_WorldEventTemplate))).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#endif
            }

            return _cache;
        }
    }

    // -----------------------------------------------------------------------------------
}