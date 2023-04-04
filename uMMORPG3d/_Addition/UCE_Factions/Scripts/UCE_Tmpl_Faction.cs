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

// PRESTIGE CLASS - TEMPLATE

[CreateAssetMenu(fileName = "UCE_Tmpl_Faction", menuName = "UCE/Template/Faction", order = 0)]
public class UCE_Tmpl_Faction : ScriptableObject
{
    [Header("-=-=-=- UCE FACTION -=-=-=-")]
    public Sprite image;

    [TextArea(1, 10)] public string description;

    public UCE_FactionRank[] ranks;
#if _CSPVPREALMS

    [Tooltip("Monsters set to 'aggressive' will only attack a player when their faction ranking falls below this threshold.")]
    public float aggressiveThreshold;

#endif

    // -----------------------------------------------------------------------------------
    // getRank
    // -----------------------------------------------------------------------------------
    public string getRank(int rating)
    {
        foreach (UCE_FactionRank rank in ranks)
            if (rank.min <= rating && rank.max >= rating) return rank.name;

        return "???";
    }

    // -----------------------------------------------------------------------------------
    // getRank
    // -----------------------------------------------------------------------------------
    public string getRank(int min, int max)
    {
        foreach (UCE_FactionRank rank in ranks)
            if (min >= rank.min && max <= rank.max) return rank.name;

        return "???";
    }

    // -----------------------------------------------------------------------------------
    // checkAggressive
    // -----------------------------------------------------------------------------------
    public bool checkAggressive(int rating)
    {
#if _CSPVPREALMS
        return (rating <= aggressiveThreshold);
#else
        return false;
#endif
    }

    // -----------------------------------------------------------------------------------
    // Caching
    // -----------------------------------------------------------------------------------
    private static Dictionary<int, UCE_Tmpl_Faction> _cache;

    public static Dictionary<int, UCE_Tmpl_Faction> dict
    {
        get
        {
            if (_cache == null)
            {
                UCE_ScripableObjectEntry entry = UCE_TemplateConfiguration.singleton.GetEntry(typeof(UCE_Tmpl_Faction));
                string folderName = entry != null ? entry.folderName : "";
#if _CSASSETBUNDLEMANAGER
                if (entry != null && entry.loadFromAssetBundle)
                    _cache = AssetBundleMagic.LoadBundle(entry.bundleName).LoadAllAssets<UCE_Tmpl_Faction>().ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
                else
                    _cache = Resources.LoadAll<UCE_Tmpl_Faction>(folderName).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#else
                _cache = Resources.LoadAll<UCE_Tmpl_Faction>(UCE_TemplateConfiguration.singleton.GetTemplatePath(typeof(UCE_Tmpl_Faction))).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#endif
            }

            return _cache;
        }
    }

    // -----------------------------------------------------------------------------------
}