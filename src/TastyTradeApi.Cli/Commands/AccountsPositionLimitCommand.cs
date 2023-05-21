using System.CommandLine;
using TastyTradeApi.Cli.Utils;

namespace TastyTradeApi.Cli.Commands;

internal class AccountsPositionLimitCommand : AuthenticatedCommandBase
{
    private Argument<string> _accountArgument = new Argument<string>("account", "The account number");
    internal AccountsPositionLimitCommand() : base("position-limit", "Gets the account position limits")
    {
        AddArgument(_accountArgument);

        this.SetHandler(HandleCommand, _accountArgument);
    }

    private async Task HandleCommand(string account)
    {
        var client = GetClient();
        var limits = await client.AccountService.GetPositionLimit(account);
        ConsoleWriter.WriteData(limits?.Data);
    }
}
