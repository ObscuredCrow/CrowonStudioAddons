// =======================================================================================
// Created and maintained by Crowon Studio
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/UBnh2xfdeZ
// * Website............................: https://crowon-studio.com
// =======================================================================================

// UCE ADMINISTRATION - CHAT

public partial class PlayerChat
{
    protected UCE_AdministrationConsole ac;

    // -----------------------------------------------------------------------------------
    //
    // -----------------------------------------------------------------------------------
    [DevExtMethods("OnSubmit")]
    private void OnSubmit_UCE_Administration(string text)
    {
        Player player = Player.localPlayer;
        if (!player || player.UCE_adminLevel <= 0 || string.IsNullOrWhiteSpace(text)) return;

        if (ac == null)
            ac = player.GetComponent<UCE_AdministrationConsole>();

        if (ac != null)
            ac.ProcessCommand(text);
    }
}