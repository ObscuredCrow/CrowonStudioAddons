// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using System.Collections.Generic;

public class DontDestroyOnLoad : MonoBehaviour
{
    public Dictionary<string, DontDestroyOnLoad> singletons = new Dictionary<string, DontDestroyOnLoad>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // if we load the initial scene again then the object will exists twice
        // so let's make sure to delete any duplicates
        // -> its important to keep the exact ones so that server/client ids are
        //    the same
        if (!singletons.ContainsKey(name))
            singletons[name] = this;
        else Destroy(gameObject);
    }
}