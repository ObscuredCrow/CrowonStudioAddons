// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

using System.Text;

public partial struct Item
{
    public string itemCategory
    {
        get { return data.itemCategory; }
    }

    [DevExtMethods("ToolTip")]
    private void ToolTip_UCE_NpcShop(StringBuilder tip)
    {
        tip.Replace("{ITEMCATEGORY}", itemCategory);
    }
}