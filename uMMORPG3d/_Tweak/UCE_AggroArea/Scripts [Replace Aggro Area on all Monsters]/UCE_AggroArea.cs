// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;
using UnityEngine.AI;

// AGGRO AREA

[RequireComponent(typeof(SphereCollider))]
public partial class UCE_AggroArea : MonoBehaviour
{
    protected Entity owner;

    private void Awake()
    {
        owner = GetComponentInParent<Entity>();
    }

    private void OnTriggerEnter(Collider co)
    {
        AggroCheck(co.GetComponentInParent<Entity>());
    }

    private void OnTriggerStay(Collider co)
    {
        AggroCheck(co.GetComponentInParent<Entity>());
    }

    private void AggroCheck(Entity entity)
    {
        if (owner.UCE_CanAttack(entity)) owner.OnAggro(entity);
#if _CSAGGROOVERLAY
        if (owner is Monster) Utils.InvokeMany(typeof(Monster), (Entity)owner, "OnClientAggro_", entity);
#endif
    }
}