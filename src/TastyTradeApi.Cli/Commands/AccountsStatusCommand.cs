using System.CommandLine;
using TastyTradeApi.Cli.Utils;

namespace TastyTradeApi.Cli.Commands;

public class AccountsStatusCommand : AuthenticatedCommandBase
{
    private Argument<string> _accountArgument = new Argument<string>("account", "The account number");

    public AccountsStatusCommand() : base("status", "Gets the account status")
    {
        AddArgument(_accountArgument);

        this.SetHandler(HandleCommand, _accountArgument);
    }

    private async Task HandleCommand(string account)
    {
        var client = GetClient();
        var tradingStatus = await client.AccountService.GetTradingStatus(account);
        ConsoleWriter.WriteData(tradingStatus?.Data);
    }
}
