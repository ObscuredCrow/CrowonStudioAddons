// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using UnityEngine;

// BuffChecker

public class UCE_BuffChecker : MonoBehaviour
{
    [Header("[UCE BUFF CHECKER]")]
    public UCE_BuffCheckerEntry[] buffEntry;

    protected Entity entity;
    protected Animator animator;
    protected float cacheTimerInterval = 1.0f;
    protected float _cacheTimer;

    // -----------------------------------------------------------------------------------
    // Start
    // -----------------------------------------------------------------------------------
    private void Start()
    {
        entity = GetComponent<Entity>();
        animator = entity.animator;
    }

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        if (Time.time == 0 || Time.time > _cacheTimer)
        {
            if (entity == null) return;

            foreach (UCE_BuffCheckerEntry entry in buffEntry)
            {
                if(entity.buffs.Count > 0)
                {
                    for (int i = 0; i < entity.buffs.Count; ++i)
                    {
                        if (entity.buffs[i].name == entry.buffSkill.name && (entity.state == entry.state || entry.state == ""))
                        {
                            entry.ToggleGameObject(true);

                            if (entry.animationIndex != -1)
                                animator.SetInteger("IndexBuff", entry.animationIndex);

                            break;
                        }
                    }
                }
                else
                {
                    entry.ToggleGameObject(false);

                    if (entry.animationIndex != -1)
                        animator.SetInteger("IndexBuff", -1);
                }
            }

            _cacheTimer = Time.time + cacheTimerInterval;
        }
    }

    // -----------------------------------------------------------------------------------
}