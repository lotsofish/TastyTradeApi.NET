using System.CommandLine;
using TastyTradeApi.Cli.Utils;

namespace TastyTradeApi.Cli.Commands;

internal class AccountsTotalFeesCommand : AuthenticatedCommandBase
{
    private Argument<string> _accountArgument = new Argument<string>("account", "The account number");

    public AccountsTotalFeesCommand() : base("total-fees", "Gets today's total fees")
    {
        AddArgument(_accountArgument);

        this.SetHandler(HandleCommand, _accountArgument);
    }

    private async Task HandleCommand(string account)
    {
        var client = GetClient();
        var totalFees = await client.AccountService.GetTotalFees(account);
        ConsoleWriter.WriteData(totalFees?.Data);
    }
}
