// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UCE_UI_StatsOverlay : MonoBehaviour
{
    private GameObject healthBar;
    private Entity entity;
    private float currentHealth;

    // Grabs our starting components.
    private void Start()
    {
        healthBar = transform.GetChild(0).transform.GetChild(0).gameObject;
        entity = transform.parent.GetComponent<Entity>();
        SetHealth(entity.health);
    }

    // Update is called once per frame
    private void Update()
    {
        if (entity.health != currentHealth) SetHealth(entity.health);
    }

    // LateUpdate so that all camera updates are finished.
    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }

    // Sets up our visible overlay for health.
    private void SetHealth(float amount)
    {
        currentHealth = amount;

        float displayedHealth = currentHealth / entity.healthMax;
        healthBar.transform.localScale = new Vector3(displayedHealth, 1, 1);
    }
}