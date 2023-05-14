using System.CommandLine;

namespace TastyTradeApi.Cli.Commands;

public class LogoutCommand : AuthenticatedCommandBase
{
    public LogoutCommand() : base("logout", "Logout from the TastyTrade API")
    {
        this.SetHandler(() =>
        {
            SessionFileService.RemoveSessionFile();
            Console.WriteLine("Logged out.");
        });
    }
}
