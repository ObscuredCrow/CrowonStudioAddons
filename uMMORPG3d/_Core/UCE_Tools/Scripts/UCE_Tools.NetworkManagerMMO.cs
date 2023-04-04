// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// NetworkManagerMMO
public partial class NetworkManagerMMO
{
    // -----------------------------------------------------------------------------------
    // Start_UCE_Tools
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Start")]
    private void Start_UCE_Tools()
    {
#if _SERVER && !_CLIENT
        StartServer();
#endif
    }

    // -----------------------------------------------------------------------------------
}