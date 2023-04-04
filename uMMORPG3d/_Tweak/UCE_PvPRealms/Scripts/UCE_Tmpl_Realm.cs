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

// REALM - TEMPLATE

[CreateAssetMenu(fileName = "UCE Realm", menuName = "UCE/Template/Realm", order = 0)]
public class UCE_Tmpl_Realm : ScriptableObject
{
    [Header("-=-=-=- UCE REALM -=-=-=-")]
    public Sprite image;

    [TextArea(1, 10)] public string description;

    // -----------------------------------------------------------------------------------
    // Caching
    // -----------------------------------------------------------------------------------
    private static Dictionary<int, UCE_Tmpl_Realm> _cache;

    public static Dictionary<int, UCE_Tmpl_Realm> dict
    {
        get
        {
            if (_cache == null)
            {
                UCE_ScripableObjectEntry entry = UCE_TemplateConfiguration.singleton.GetEntry(typeof(UCE_Tmpl_Realm));
                string folderName = entry != null ? entry.folderName : "";
#if _CSASSETBUNDLEMANAGER
                if (entry != null && entry.loadFromAssetBundle)
                    _cache = AssetBundleMagic.LoadBundle(entry.bundleName).LoadAllAssets<UCE_Tmpl_Realm>().ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
                else
                    _cache = Resources.LoadAll<UCE_Tmpl_Realm>(folderName).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#else
                _cache = Resources.LoadAll<UCE_Tmpl_Realm>(UCE_TemplateConfiguration.singleton.GetTemplatePath(typeof(UCE_Tmpl_Realm))).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#endif
            }

            return _cache;
        }
    }

    // -----------------------------------------------------------------------------------
}