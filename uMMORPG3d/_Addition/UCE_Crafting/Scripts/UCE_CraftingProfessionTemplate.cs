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

#if _CSCRAFTING

// CRAFTING PROFESSION TEMPLATE

[CreateAssetMenu(fileName = "New UCE Crafting Profession", menuName = "UCE/Template/Crafting Profession", order = 0)]
public class UCE_CraftingProfessionTemplate : ScriptableObject
{
    [Header("Crafting Profession")]
    public int[] levels;

    public string[] categories;
    public Sprite image;
    public string playerAnimation;

    [Tooltip("[Optional] Sound effect that is played, when the player starts crafting.")]
    public AudioClip startPlayerSound;

    [Tooltip("[Optional] Sound effect that is played, when the player finishes crafting.")]
    public AudioClip stopPlayerSound;

    [TextArea(1, 30)] public string toolTip;

    // -----------------------------------------------------------------------------------
    // Caching
    // -----------------------------------------------------------------------------------
    private static Dictionary<int, UCE_CraftingProfessionTemplate> _cache;

    public static Dictionary<int, UCE_CraftingProfessionTemplate> dict
    {
        get
        {
            if (_cache == null)
            {
                UCE_ScripableObjectEntry entry = UCE_TemplateConfiguration.singleton.GetEntry(typeof(UCE_CraftingProfessionTemplate));
                string folderName = entry != null ? entry.folderName : "";
#if _CSASSETBUNDLEMANAGER
                if (entry != null && entry.loadFromAssetBundle)
                    _cache = AssetBundleMagic.LoadBundle(entry.bundleName).LoadAllAssets<UCE_CraftingProfessionTemplate>().ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
                else
                    _cache = Resources.LoadAll<UCE_CraftingProfessionTemplate>(folderName).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#else
                _cache = Resources.LoadAll<UCE_CraftingProfessionTemplate>(UCE_TemplateConfiguration.singleton.GetTemplatePath(typeof(UCE_CraftingProfessionTemplate))).ToDictionary(x => x.name.GetDeterministicHashCode(), x => x);
#endif
            }

            return _cache;
        }
    }

    // -----------------------------------------------------------------------------------
}

#endif