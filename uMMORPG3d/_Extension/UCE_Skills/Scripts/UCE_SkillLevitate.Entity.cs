// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public partial class Entity
{
    protected float _levitateHeight = 0;

    // -----------------------------------------------------------------------------------
    // Update_UCE_SkillLevitate
    // -----------------------------------------------------------------------------------
    [DevExtMethods("Update")]
    private void Update_UCE_SkillLevitate()
    {
        float levitateHeight = buffs.Sum(buff => buff.levitateHeight);

        if (levitateHeight > 0)
        {
            _levitateHeight = levitateHeight;

            if (GetComponent<NavMeshAgent>().baseOffset < levitateHeight)
                GetComponent<NavMeshAgent>().baseOffset += levitateHeight * Time.deltaTime;
        }
        else
        {
            if (GetComponent<NavMeshAgent>().baseOffset > 0)
                GetComponent<NavMeshAgent>().baseOffset -= _levitateHeight * Time.deltaTime;
        }
    }

    // -----------------------------------------------------------------------------------
}