using System.CommandLine;
using TastyTradeApi.Cli.Utils;

namespace TastyTradeApi.Cli.Commands;

internal class AccountsListCommand : AuthenticatedCommandBase
{
    public AccountsListCommand() : base("list", "Lists your accounts")
    {
        this.SetHandler(HandleCommand);
    }

    internal async Task HandleCommand()
    {
        var client = GetClient();
        var balance = await client.AccountService.GetAccounts();
        ConsoleWriter.WriteData(balance?.Data);
    }
}
