using System.CommandLine;
using TastyTradeApi.Cli.Utils;

namespace TastyTradeApi.Cli.Commands;

internal class BalanceCommand : AuthenticatedCommandBase
{
    private Argument<string> _accountArgument = new Argument<string>("account");
    private Option<bool> _allOption = new Option<bool>("--all", "Shows all the account balance properties");
    private List<string> propertiesToDisplay = new() { "AccountNumber", "NetLiquidatingValue", "CashBalance", "MarginEquity", "EquityBuyingPower" };

    internal BalanceCommand() : base("balance", "Shows the current balance")
    {
        this.AddArgument(_accountArgument);
        this.AddOption(_allOption);

        this.SetHandler(HandleCommand, _accountArgument, _allOption);
    }

    private async Task HandleCommand(string account, bool all)
    {
        var client = GetClient();
        var balance = await client.AccountService.GetBalance(account);
        ConsoleWriter.WriteData(balance?.Data, propertiesToDisplay, all);
    }
}