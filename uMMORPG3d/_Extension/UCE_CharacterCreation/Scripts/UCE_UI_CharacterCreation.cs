// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if _UMA

using UMA;
using UMA.CharacterSystem;

#endif

public partial class UCE_UI_CharacterCreation : MonoBehaviour
{
    [Header("-=-=-=- UCE Character Creation -=-=-=-")]
    public GameObject panel;

    public GameObject centerPanel, centerPanel2;

#if _CSTRAITS
    public UCE_UI_CharacterTraits traitsPanel;
#endif

    public List<UCE_CharacterCreationClass> classList = new List<UCE_CharacterCreationClass>();
    public bool lookAtCamera;
    public GameObject SpawnPoint;
    public NetworkManagerMMO manager;

    public Transform creationCameraLocation;

    [Header("-=-=-=- Creation Panel -=-=-=-")]
    public InputField nameInput;

    public Button createButton;
    public Button cancelButton;

    protected List<Player> players;
    protected int classIndex = 0;
    protected bool bInit = false;

#if _CSUMA

    [Header("-=-=-=- UMA -=-=-=-")]
#if _UMA
    public List<UMATextRecipe> maleHairStyles;
    public List<UMATextRecipe> maleClothing;
    public List<UMATextRecipe> femaleHairStyles;
    public List<UMATextRecipe> femaleClothing;

    [HideInInspector]
    public DynamicCharacterAvatar dca;
#endif

    [HideInInspector]
    public int maleIndex = 0;

    [HideInInspector]
    public int femaleIndex = 0;

    [HideInInspector]
    public int maleClothingIndex = 0;

    [HideInInspector]
    public int femaleClothingIndex = 0;

#endif

    // -----------------------------------------------------------------------------------
    // currentPlayer
    // -----------------------------------------------------------------------------------
    public Player currentPlayer
    {
        get
        {
            return players[classIndex];
        }
    }

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show()
    {
#if _CSUMA && _UMA
        centerPanel.SetActive(true);
        centerPanel2.SetActive(true);
#else
        centerPanel.SetActive(false);
        centerPanel2.SetActive(false);
#endif

        Camera.main.transform.position = creationCameraLocation.position;
        Camera.main.transform.rotation = creationCameraLocation.rotation;

        players = new List<Player>();
        players = manager.playerClasses;

        if (players == null || players.Count <= 0)
        {
            return;
        }

        for (int c = 0; c < players.Count; c++)
        {
            int temp = c;

            classList[temp].button.onClick.SetListener(() => SetCharacterClass(temp));
            classList[temp].label.text = players[temp].name;
            classList[temp].prefabID = temp;

#if _CSUNLOCKABLECLASSES
            if (manager.UCE_HasUnlockedClass(players[temp]))
            {
                classList[temp].button.gameObject.SetActive(true);
            }
            else
            {
                classList[temp].button.gameObject.SetActive(false);
            }
#else
            classList[temp].button.gameObject.SetActive(true);
#endif
        }

#if _CSUNLOCKABLECLASSES
        for (int c = 0; c < players.Count; c++)
        {
            int selectedClass = c;
            if (manager.UCE_HasUnlockedClass(players[selectedClass]))
            {
                SetCharacterClass(selectedClass);
                break;
            }
        }
#else
        SetCharacterClass(0);
#endif

        createButton.onClick.SetListener(() =>
        {
            CreateCharacter();
        });

        cancelButton.onClick.SetListener(() =>
        {
            Hide();
        });

        panel.SetActive(true);

        bInit = true;
    }

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        if (!bInit) return;

        if (nameInput.text.Length == 0)
            createButton.enabled = false;
        else
            createButton.enabled = true;
    }

    // -----------------------------------------------------------------------------------
    // CreateCharacter
    // -----------------------------------------------------------------------------------
    public virtual void CreateCharacter()
    {
        if (SpawnPoint.transform.childCount > 0)
            Destroy(SpawnPoint.transform.GetChild(0).gameObject);

#if _CSTRAITS
        int[] iTraits = new int[traitsPanel.currentTraits.Count];

        for (int i = 0; i < traitsPanel.currentTraits.Count; i++)
        {
            iTraits[i] = traitsPanel.currentTraits[i].name.GetDeterministicHashCode();
        }

        CharacterCreateMsg message = new CharacterCreateMsg
        {
            name = nameInput.text,
            classIndex = classIndex,
            traits = iTraits
#if _CSUMA && _UMA
            ,
            dna = CompressedString()
#endif
        };
#else
        CharacterCreateMsg message = new CharacterCreateMsg
        {
            name = nameInput.text,
            classIndex = classIndex
#if _CSUMA
            , dna = CompressedString()
#endif
        };

#endif

        NetworkClient.Send(message);

        Hide();
    }

    // -----------------------------------------------------------------------------------
    //
    // -----------------------------------------------------------------------------------
    public virtual void SetCharacterClass(int _classIndex)
    {
        classIndex = _classIndex;

        if (SpawnPoint.transform.childCount > 0)
            Destroy(SpawnPoint.transform.GetChild(0).gameObject);

        GameObject go = Instantiate(players[classIndex].gameObject, SpawnPoint.transform.position, SpawnPoint.transform.rotation);

        go.transform.parent = SpawnPoint.transform;

        if (lookAtCamera)
            go.transform.LookAt(creationCameraLocation);

        Player player = go.GetComponent<Player>();

        for (int i = 0; i < players[classIndex].equipmentInfo.Length; ++i)
        {
            EquipmentInfo info = players[classIndex].equipmentInfo[i];
            player.equipment.Add(info.defaultItem.item != null ? new ItemSlot(new Item(info.defaultItem.item), info.defaultItem.amount) : new ItemSlot());
            player.RefreshLocation(i);
        }

#if _CSTRAITS
        traitsPanel.Show();
#endif
#if _CSUMA
        SetupAll();
#endif
    }

    // -----------------------------------------------------------------------------------
    // Hide
    // -----------------------------------------------------------------------------------
    public void Hide()
    {
        if (SpawnPoint.transform.childCount > 0)
            Destroy(SpawnPoint.transform.GetChild(0).gameObject);

#if _CSTRAITS
        traitsPanel.Hide();
#endif

        panel.SetActive(false);
        bInit = false;

        Camera.main.transform.position = manager.selectionCameraLocation.position;
        Camera.main.transform.rotation = manager.selectionCameraLocation.rotation;

#if _CSUMA && _UMA
        dca = null;
#endif
    }

    public bool IsVisible()
    {
        return panel.activeSelf;
    }

#if _CSUMA

    public void SetupAll()
    {
#if _UMA
        dca = FindObjectOfType<DynamicCharacterAvatar>();
        StartCoroutine(Setup());
#endif
    }

    private IEnumerator Setup()
    {
        yield return new WaitForSeconds(0.1f);
#if _UMA
        dca.ChangeRace("HumanMale");
        yield return new WaitForSeconds(0.1f);
        if (maleClothing.Count > 0)
            SelectClothing(0);
        yield return new WaitForSeconds(0.1f);
        if (maleHairStyles.Count > 0)
            SelectHair(0);
#endif
    }

    public void SelectClothing(int index)
    {
#if _UMA
        bool male = dca.activeRace.name == "HumanMale" ? true : false;
        dca.ClearSlot("Underwear");

        if (male)
            dca.SetSlot(maleClothing[index]);
        if (!male)
            dca.SetSlot(femaleClothing[index]);

        dca.BuildCharacter();
#endif
    }

    public void SelectHair(int index)
    {
#if _UMA
        bool male = dca.activeRace.name == "HumanMale" ? true : false;
        dca.ClearSlot("Hair");

        if (male)
            dca.SetSlot(maleHairStyles[index]);
        if (!male)
            dca.SetSlot(femaleHairStyles[index]);

        dca.BuildCharacter();
#endif
    }

    public void SwitchGender(string genderName)
    {
#if _UMA
        dca.ChangeRace(genderName);

        if (genderName == "HumanMale")
        {
            if (maleClothing.Count > 0)
                SelectClothing(maleClothingIndex);

            if (maleHairStyles.Count > 0)
                SelectHair(maleIndex);
        }
        if (genderName == "HumanFemale")
        {
            if (femaleClothing.Count > 0)
                SelectClothing(femaleClothingIndex);

            if (maleHairStyles.Count > 0)
                SelectHair(femaleIndex);
        }
#endif
    }

    public void ChangeHairColor(Color col)
    {
#if _UMA
        dca.SetColor("Hair", col);
        dca.UpdateColors(true);
#endif
    }

    public void ChangeBaseColor(Color col)
    {
#if _UMA
        dca.SetColor("Undies", col);
        dca.UpdateColors(true);
#endif
    }

    public void ChangeEyesColor(Color col)
    {
#if _UMA
        dca.SetColor("Eyes", col);
        dca.UpdateColors(true);
#endif
    }

    public void ChangeSkinColor(Color col)
    {
#if _UMA
        dca.SetColor("Skin", col);
        dca.UpdateColors(true);
#endif
    }

#if _UMA

    private String CompressedString()
    {
        return CompressUMA.Compressor.CompressDna(dca.GetCurrentRecipe());
    }

#endif

#endif
    // -----------------------------------------------------------------------------------
}