// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.UI;

public partial class UIStamina : MonoBehaviour
{
    public GameObject panel;
    public Slider staminaSlider;
    public Text staminaStatus;

    private void Update()
    {
        Player player = Player.localPlayer;
        if (player)
        {
            panel.SetActive(true);

            staminaSlider.value = player.StaminaPercent();
            staminaStatus.text = player.stamina + " / " + player.staminaMax;
        }
    }
}