// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using Mirror;
using System.Linq;

#if _CSHARVESTING

// HARVESTING PROFESSION

public struct UCE_HarvestingProfession
{
    public string templateName;
    public long experience;

    // -----------------------------------------------------------------------------------
    // UCE_HarvestingProfession (Constructor)
    // -----------------------------------------------------------------------------------
    public UCE_HarvestingProfession(string _templateName)
    {
        templateName = _templateName;
        experience = 0;
    }

    // -----------------------------------------------------------------------------------
    // level (Getter)
    // -----------------------------------------------------------------------------------
    public int level
    {
        get
        {
            long exp = this.experience;
            return 1 + template.levels.Count(l => l <= exp);
        }
    }

    // -----------------------------------------------------------------------------------
    // maxlevel (Getter)
    // -----------------------------------------------------------------------------------
    public int maxlevel
    {
        get { return 1 + template.levels.Count(); }
    }

    // -----------------------------------------------------------------------------------
    // experiencePercent (Getter)
    // -----------------------------------------------------------------------------------
    public float experiencePercent
    {
        get
        {
            return (experience != 0 && experienceNext != 0) ? (float)(experience - experiencePrevious) / (float)(experienceNext - experiencePrevious) : 0;
        }
    }

    // -----------------------------------------------------------------------------------
    // experiencePrevious (Getter)
    // -----------------------------------------------------------------------------------
    public long experiencePrevious
    {
        get
        {
            if (level == 1)
                return 0;
            else
                return template.levels[level - 2];
        }
    }

    // -----------------------------------------------------------------------------------
    // experienceNext (Getter)
    // -----------------------------------------------------------------------------------
    public long experienceNext
    {
        get
        {
            long exp = this.experience;

            if (level == maxlevel)
            {
                return exp;
            }
            else if (level > 1)
            {
                return template.levels[level - 1];
            }
            return template.levels[0];
        }
    }

    // -----------------------------------------------------------------------------------
    // UCE_HarvestingProfessionTemplate (Getter)
    // -----------------------------------------------------------------------------------
    public UCE_HarvestingProfessionTemplate template
    {
        get { return UCE_HarvestingProfessionTemplate.dict[templateName.GetDeterministicHashCode()]; }
    }

    // -----------------------------------------------------------------------------------
}

public class SyncListUCE_HarvestingProfession : SyncList<UCE_HarvestingProfession> { }

#endif