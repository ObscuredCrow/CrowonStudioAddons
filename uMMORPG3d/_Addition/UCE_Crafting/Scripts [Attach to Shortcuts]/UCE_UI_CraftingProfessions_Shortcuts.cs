// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

// SHORTCUTS

public partial class UCE_UI_CraftingProfessions_Shortcuts : MonoBehaviour
{
    public Button CraftingProfessionsButton;
    public GameObject CraftingProfessionsPanel;

    public Button CraftingRecipesButton;
    public GameObject CraftingRecipesPanel;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    public void Update()
    {
        CraftingProfessionsButton.onClick.SetListener(() =>
        {
            CraftingProfessionsPanel.SetActive(!CraftingProfessionsPanel.activeSelf);
        });

        CraftingRecipesButton.onClick.SetListener(() =>
        {
            CraftingRecipesPanel.SetActive(!CraftingRecipesPanel.activeSelf);
        });
    }

    // -----------------------------------------------------------------------------------
}