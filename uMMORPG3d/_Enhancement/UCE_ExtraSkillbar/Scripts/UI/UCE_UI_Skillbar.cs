// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// UCE UI Skillbar

public partial class UCE_UI_Skillbar : MonoBehaviour
{
    public GameObject panel;
    public UCEUISkillbarSlot slotPrefab;
    public Transform content;

    [Header("[-=-=- UCE UI Element -=-=-]")]
    [SerializeField] [Range(0.01f, 3f)] private float updateInterval = 0.25f;

    protected float fInterval;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        Player player = Player.localPlayer;

        if (player == null)
        {
            panel.SetActive(false);
            return;
        }
        else
        {
            panel.SetActive(true);
        }

        if (Time.time > fInterval)
        {
            UCE_SlowUpdate();
            fInterval = Time.time + updateInterval;
        }

        if (player != null && panel.activeSelf)
        {
            if (content.childCount <= 0)
                return;

            for (int i = 0; i < player.UCE_skillbar.Length; ++i)
            {
                UCEUISkillbarSlot slot = content.GetChild(i).GetComponent<UCEUISkillbarSlot>();

                // skill, inventory item or equipment item?
                int skillIndex = player.GetSkillIndexByName(player.UCE_skillbar[i].reference);
                int inventoryIndex = player.GetInventoryIndexByName(player.UCE_skillbar[i].reference);

                if (skillIndex != -1)
                {
                    Skill skill = player.skills[skillIndex];
                    bool canCast = player.CastCheckSelf(skill);

                    // hotkey pressed and not typing in any input right now?
                    if (Input.GetKeyDown(player.UCE_skillbar[i].hotKey) &&
                        !UIUtils.AnyInputActive() &&
                        canCast) // checks mana, cooldowns, etc.) {
                    {
                        // try use the skill or walk closer if needed
                        player.TryUseSkill(skillIndex);
                    }
                }
                else if (inventoryIndex != -1)
                {
                    ItemSlot itemSlot = player.inventory[inventoryIndex];

                    // hotkey pressed and not typing in any input right now?
                    if (Input.GetKeyDown(player.UCE_skillbar[i].hotKey) && !UIUtils.AnyInputActive())
                        player.CmdUseInventoryItem(inventoryIndex);
                }
            }
        }
        else panel.SetActive(false);
    }

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void UCE_SlowUpdate()
    {
        Player player = Player.localPlayer;
        if (player != null && panel.activeSelf)
        {
            // instantiate/destroy enough slots
            UIUtils.BalancePrefabs(slotPrefab.gameObject, player.UCE_skillbar.Length, content);

            // refresh all
            for (int i = 0; i < player.UCE_skillbar.Length; ++i)
            {
                UCEUISkillbarSlot slot = content.GetChild(i).GetComponent<UCEUISkillbarSlot>();
                slot.dragAndDropable.name = i.ToString(); // drag and drop index

                // hotkey overlay (without 'Alpha' etc.)
                string pretty = player.UCE_skillbar[i].hotKey.ToString().Replace("Alpha", "");
                slot.hotkeyText.text = pretty;

                // skill, inventory item or equipment item?
                int skillIndex = player.GetSkillIndexByName(player.UCE_skillbar[i].reference);
                int inventoryIndex = player.GetInventoryIndexByName(player.UCE_skillbar[i].reference);
                int equipmentIndex = player.GetEquipmentIndexByName(player.UCE_skillbar[i].reference);
                if (skillIndex != -1)
                {
                    Skill skill = player.skills[skillIndex];
                    bool canCast = player.CastCheckSelf(skill);

                    // refresh skill slot
                    slot.button.interactable = canCast; // check mana, cooldowns, etc.
                    slot.button.onClick.SetListener(() =>
                    {
                        // try use the skill or walk closer if needed
                        player.TryUseSkill(skillIndex);
                    });
                    slot.tooltip.enabled = true;
                    slot.tooltip.text = skill.ToolTip();
                    slot.dragAndDropable.dragable = true;
                    slot.image.color = Color.white;
                    slot.image.sprite = skill.image;
                    float cooldown = skill.CooldownRemaining();
                    slot.cooldownOverlay.SetActive(cooldown > 0);
                    slot.cooldownText.text = cooldown.ToString("F0");
                    slot.cooldownCircle.fillAmount = skill.cooldown > 0 ? cooldown / skill.cooldown : 0;
                    slot.amountOverlay.SetActive(false);
                }
                else if (inventoryIndex != -1)
                {
                    ItemSlot itemSlot = player.inventory[inventoryIndex];

                    // refresh inventory slot
                    slot.button.onClick.SetListener(() =>
                    {
                        player.CmdUseInventoryItem(inventoryIndex);
                    });
                    slot.tooltip.enabled = true;
                    slot.tooltip.text = itemSlot.ToolTip();
                    slot.dragAndDropable.dragable = true;
                    slot.image.color = Color.white;
                    slot.image.sprite = itemSlot.item.image;
                    slot.cooldownOverlay.SetActive(false);
                    slot.cooldownCircle.fillAmount = 0;
                    slot.amountOverlay.SetActive(itemSlot.amount > 1);
                    slot.amountText.text = itemSlot.amount.ToString();
                }
                else if (equipmentIndex != -1)
                {
                    ItemSlot itemSlot = player.equipment[equipmentIndex];

                    // refresh equipment slot
                    slot.button.onClick.RemoveAllListeners();
                    slot.tooltip.enabled = true;
                    slot.tooltip.text = itemSlot.ToolTip();
                    slot.dragAndDropable.dragable = true;
                    slot.image.color = Color.white;
                    slot.image.sprite = itemSlot.item.image;
                    slot.cooldownOverlay.SetActive(false);
                    slot.cooldownCircle.fillAmount = 0;
                    slot.amountOverlay.SetActive(itemSlot.amount > 1);
                    slot.amountText.text = itemSlot.amount.ToString();
                }
                else
                {
                    // clear the outdated reference
                    player.UCE_skillbar[i].reference = "";

                    // refresh empty slot
                    slot.button.onClick.RemoveAllListeners();
                    slot.tooltip.enabled = false;
                    slot.dragAndDropable.dragable = false;
                    slot.image.color = Color.clear;
                    slot.image.sprite = null;
                    slot.cooldownOverlay.SetActive(false);
                    slot.cooldownCircle.fillAmount = 0;
                    slot.amountOverlay.SetActive(false);
                }
            }
        }
    }

    // -----------------------------------------------------------------------------------
}