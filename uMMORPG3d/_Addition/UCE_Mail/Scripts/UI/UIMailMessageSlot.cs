// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// Attach to the prefab for easier component access by the UI Scripts.
// Otherwise we would need slot.GetChild(0).GetComponentInChildren<Text> etc.
using UnityEngine;
using UnityEngine.UI;

public class UIMailMessageSlot : MonoBehaviour
{
    public Text textReceived;
    public Text textFrom;
    public Text textSubject;
    public Button readButton;
    public Button itemSlot;
    public Toggle toggle;
    [HideInInspector] public int mailIndex;
}