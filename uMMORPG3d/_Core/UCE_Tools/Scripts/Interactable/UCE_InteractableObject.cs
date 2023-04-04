// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using UnityEngine;

// ===================================================================================
// UCE INTERACTABLE OBJECT CLASS
// ===================================================================================
public partial class UCE_InteractableObject : UCE_Interactable
{
    public enum InteractionRangeType { Any, Quadruple, Double, Normal, Half, Quarter }

    [Tooltip("[Optional] Interaction range limit?")]
    public InteractionRangeType interactionRangeType;

    [Tooltip("[Optional] Once a player accessed it, everybody can interact with it?")]
    public bool unlockPermanently = false;

    [Header("[COMPONENTS]")]
    public new Collider collider;

    public NetworkProximityGridChecker proxchecker;
    public Transform effectMount;
    public AudioSource audioSource;

    // -----------------------------------------------------------------------------------
    // Start
    // -----------------------------------------------------------------------------------
    public override void Start()
    {
        base.Start();
        OnLock();
    }

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    public virtual void Update()
    {
        if (isClient)
        {
            OnUpdateClient();
        }
        if (isServer)
        {
            OnUpdateServer();
        }
    }

    // -----------------------------------------------------------------------------------
    // OnUpdateClient
    // @Client
    // -----------------------------------------------------------------------------------
    [ClientCallback]
    public virtual void OnUpdateClient()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        // -- check for interaction Distance
        this.GetComponentInChildren<SpriteRenderer>().enabled = UCE_Tools.UCE_CheckSelectionHandling(this.gameObject);

        // -- check for click
        if (UCE_Tools.UCE_SelectionHandling(this.gameObject))
        {
            if (CheckInteractionRange(player) && ((!interactionRequirements.HasRequirements() && !interactionRequirements.HasCosts()) || automaticActivation))
            {
                // -- when no requirements & no costs: automatically
                ConfirmAccess();
            }
            else if (CheckInteractionRange(player) && interactionRequirements.CheckState(player))
            {
                // -- in any other case: show confirmation UI
                ShowAccessRequirementsUI();
            }
        }
    }

    // -----------------------------------------------------------------------------------
    // OnUpdateServer
    // @Server
    // -----------------------------------------------------------------------------------
    [ServerCallback]
    public virtual void OnUpdateServer() { }

    // -----------------------------------------------------------------------------------
    // OnUnlock
    // @Server
    // -----------------------------------------------------------------------------------
    public void OnUnlock()
    {
        unlocked = unlockPermanently;
    }

    // -----------------------------------------------------------------------------------
    // OnLock
    // @Server
    // -----------------------------------------------------------------------------------
    public void OnLock()
    {
        unlocked = false;
    }

    // -----------------------------------------------------------------------------------
    // IsUnlocked
    // -----------------------------------------------------------------------------------
    public override bool IsUnlocked()
    {
        return unlocked;
    }

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    [Server]
    public void Show()
    {
        proxchecker.forceHidden = false;
    }

    // -----------------------------------------------------------------------------------
    // Hide
    // -----------------------------------------------------------------------------------
    [Server]
    public void Hide()
    {
        proxchecker.forceHidden = true;
    }

    // -----------------------------------------------------------------------------------
    // IsHidden
    // -----------------------------------------------------------------------------------
    public bool IsHidden()
    {
        return proxchecker.forceHidden;
    }

    // -----------------------------------------------------------------------------------
    // CheckInteractionRange
    // -----------------------------------------------------------------------------------
    public bool CheckInteractionRange(Player player)
    {
        if (interactionRangeType == InteractionRangeType.Any || collider == null) return true;

        float fInteractionRange = player.interactionRange;

        if (interactionRangeType == InteractionRangeType.Quadruple)
        {
            fInteractionRange *= 4;
        }
        else if (interactionRangeType == InteractionRangeType.Double)
        {
            fInteractionRange *= 2;
        }
        else if (interactionRangeType == InteractionRangeType.Half)
        {
            fInteractionRange *= 0.5f;
        }
        else if (interactionRangeType == InteractionRangeType.Quarter)
        {
            fInteractionRange *= 0.25f;
        }

        return ClosestDistance(player.collider, collider) <= fInteractionRange;
    }

    // =================================== HELPERS =======================================

    // Distance between two ClosestPoints (Used for Interacting with Objects not Entities use Utils.ClosestDistance for Entities)
    public static float ClosestDistance(Collider a, Collider b)
    {
        // at first calculate the distance from A to B, subtract both radius
        // IMPORTANT: use entity.transform.position not
        //            collider.transform.position. that would still be the hip!
        float distance = Vector3.Distance(a.transform.position, b.transform.position);

        // calculate both collider radius
        float radiusA = Utils.BoundsRadius(a.bounds);
        float radiusB = Utils.BoundsRadius(b.bounds);

        // subtract both radius
        float distanceInside = distance - radiusA - radiusB;

        // return distance. if it's <0 because they are inside each other, then
        // return 0.
        return Mathf.Max(distanceInside, 0);
    }

    // -----------------------------------------------------------------------------------
    // SpawnEffect
    // Same as SpawnEffect that is found in skill effects of the core asset. It has been
    // put here because its required for almost every skill. Prevents duplicate code.
    // -----------------------------------------------------------------------------------
    public void SpawnEffect(GameObject effectObject, AudioClip effectSound = null)
    {
        if (effectObject != null)
        {
            GameObject go = Instantiate(effectObject, effectMount.position, Quaternion.identity);
            NetworkServer.Spawn(go);
        }

        if (effectSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(effectSound);
        }
    }

    // -----------------------------------------------------------------------------------
    // PlaySound
    // -----------------------------------------------------------------------------------
    [ClientCallback]
    public void PlaySound(AudioClip effectSound = null)
    {
        if (effectSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(effectSound);
        }
    }

    // -----------------------------------------------------------------------------------
    // IsWorthUpdating
    // -----------------------------------------------------------------------------------
    public override bool IsWorthUpdating()
    {
        return netIdentity.observers == null ||
               netIdentity.observers.Count > 0 ||
               IsHidden();
    }

    // -----------------------------------------------------------------------------------
}