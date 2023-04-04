// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

#if _CSSKILLCATEGORY
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sets our new hotkeys for skills.
public partial class UCE_UI_Skills : MonoBehaviour
{
    private UCE_UI_SettingsVariables settingsVariables;

    // Grabs our settings variables.
    private void Start()
    {
        settingsVariables = FindObjectOfType<UCE_UI_SettingsVariables>().GetComponent<UCE_UI_SettingsVariables>();
    }

    // Set our hotkey based on the players selection.
    private void FixedUpdate()
    {
        if (settingsVariables != null)
            if (settingsVariables.keybindUpdate[18])
            {
                hotKey = settingsVariables.keybindings[18];
                settingsVariables.keybindUpdate[18] = false;
            }
    }
}
#endif