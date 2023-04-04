// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Linq;
using UnityEngine;

// MainStoreScreen

public class MainStoreScreen : MonoBehaviour
{
    public StoreItemContent productSlot;
    public Transform content;

    public void OnEnable()
    {
        int productCount = UCE_Tmpl_PayPalProduct.dict.Count;
        UIUtils.BalancePrefabs(productSlot.gameObject, productCount, content);

        for (int i = 0; i < productCount; ++i)
        {
            StoreItemContent slot = content.GetChild(i).GetComponent<StoreItemContent>();
            slot.Init(UCE_Tmpl_PayPalProduct.dict.ElementAt(i).Value);
        }
    }
}