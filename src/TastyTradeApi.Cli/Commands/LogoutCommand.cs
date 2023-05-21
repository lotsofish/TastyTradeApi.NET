using System.CommandLine;

namespace TastyTradeApi.Cli.Commands;

internal class LogoutCommand : AuthenticatedCommandBase
{
    internal LogoutCommand() : base("logout", "Logout from the TastyTrade API")
    {
        this.SetHandler(HandleCommand);
    }

    private async Task HandleCommand()
    {
        var client = GetClient();
        await client.SessionService.Logout();
        SessionFileService.RemoveSessionFile();
        Console.WriteLine("Logged out.");
    }
}
