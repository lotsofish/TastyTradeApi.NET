using System.CommandLine;
using TastyTradeApi.Cli.Utils;

namespace TastyTradeApi.Cli.Commands;

public class AccountsListCommand : AuthenticatedCommandBase
{
    public AccountsListCommand() : base("list", "Lists your accounts")
    {
        this.SetHandler(HandleCommand);
    }

    private async Task HandleCommand()
    {
        var client = GetClient();
        var balance = await client.AccountService.GetAccounts();
        ConsoleWriter.WriteData(balance?.Data);
    }
}
