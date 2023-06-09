﻿// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

#if _UMA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UMA;

public class UCE_UmaHairStyleButton : MonoBehaviour
{
    public int MaleHairStyleIndex = 0;
    public int FemaleHairStyleIndex = 0;
    public TextMeshProUGUI indexText;
    private UCE_UI_CharacterCreation creator;
    private Button changeButton;

    private void Start()
    {
        creator = FindObjectOfType<UCE_UI_CharacterCreation>();
        changeButton = gameObject.GetComponent<Button>();
        changeButton.onClick.SetListener(ChangeHair);
    }

    public void ChangeHair()
    {
        if (creator.dca == null) return;

        bool male = creator.dca.activeRace.name == "HumanMale" ? true : false;

        creator.SelectHair(male ? MaleHairStyleIndex : FemaleHairStyleIndex);

        if (indexText != null)
            indexText.text = ((male ? MaleHairStyleIndex : FemaleHairStyleIndex) + 1).ToString();
    }
}

#endif