// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// UCE REMEMBER ME

public partial class UILogin
{
    public Toggle remember;

    // -----------------------------------------------------------------------------------
    // Awake
    // Set our listener to save our account name, grab our account name if remember is checked.
    // -----------------------------------------------------------------------------------
    private void Awake()
    {
        if (remember)
            remember.isOn = PlayerPrefs.GetInt("RememberToggle", 0) == 1 ? true : false;

        if (remember && remember.isOn && PlayerPrefs.HasKey("Account"))
            accountInput.text = PlayerPrefs.GetString("Account");
    }

    // -----------------------------------------------------------------------------------
    // Save Account
    // Save our account name when login is clicked.
    // -----------------------------------------------------------------------------------
    private void SaveAccount()
    {
        PlayerPrefs.SetInt("RememberToggle", remember.isOn ? 1 : 0);
        PlayerPrefs.SetString("Account", accountInput.text);
    }
}