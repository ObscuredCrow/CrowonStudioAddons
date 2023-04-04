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

// HONOR CURRENCY - TEMPLATE

[CreateAssetMenu(fileName = "UCE HonorCurrency", menuName = "UCE/Template/Honor Currency", order = 0)]
public class UCE_Tmpl_HonorCurrency : ScriptableObject
{
    public Sprite image;

    [Tooltip("[Optional] This currency is only dropped if all criteria are met")]
    public UCE_Requirements dropRequirements;

    [Tooltip("[Optional] Currency amount is awarded per level of the target")]
    public bool perLevel;

    [Tooltip("[Optional] Will share a fraction of this currency with online party members")]
    public bool shareWithParty;

    [Tooltip("[Optional] Will share a fraction of this currency with online guild members")]
    public bool shareWithGuild;

#if _CSPVPREALMS

    [Tooltip("[Optional] Will share a fraction of this currency with online realm members")]
    public bool FromHostileRealmsOnly;

    public bool shareWithRealm;
#endif

    // -----------------------------------------------------------------------------------
    // Caching
    // -----------------------------------------------------------------------------------
    private static Dictionary<int, UCE_Tmpl_HonorCurrency> _cache;

    public static Dictionary<int, UCE_Tmpl_HonorCurrency> dict
    {
        get
        {
            if (_cache == null)
            {
                UCE_ScripableObjectEntry entry = UCE_TemplateConfiguration.singleton.GetEntry(typeof(UCE_Tmpl_HonorCurrency));
                string folderName = entry != null ? entry.folderName : "";
#if _CSASSETBUNDLEMANAGER
                if (entry != null && entry.loadFromAssetBundle)
                    _cache = AssetBundleMagic.LoadBundle(entry.bundleName).LoadAllAssets<UCE_Tmpl_HonorCurrency>().ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
                else
                    _cache = Resources.LoadAll<UCE_Tmpl_HonorCurrency>(folderName).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#else
                _cache = Resources.LoadAll<UCE_Tmpl_HonorCurrency>(UCE_TemplateConfiguration.singleton.GetTemplatePath(typeof(UCE_Tmpl_HonorCurrency))).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#endif
            }

            return _cache;
        }
    }

    // -----------------------------------------------------------------------------------
}