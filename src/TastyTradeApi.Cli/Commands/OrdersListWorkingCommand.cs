using System.CommandLine;
using TastyTradeApi.Cli.Utils;

namespace TastyTradeApi.Cli.Commands;

internal class OrdersListWorkingCommand : AuthenticatedCommandBase
{
    private Option<bool> _allOption = new Option<bool>("--all", "Shows all the order properties");
    private List<string> propertiesToDisplay = new() { "Size", "TimeInForce", "UnderlyingSymbol", "Price" };

    internal OrdersListWorkingCommand(Argument<string> accountArgument) : base("working", "List the working order")
    {
        AddOption(_allOption);

        this.SetHandler(HandleCommand, accountArgument, _allOption);
    }

    private async Task HandleCommand(string account, bool all)
    {
        var client = GetClient();
        var workingOrders = await client.OrderService.GetLiveOrders(account);
        ConsoleWriter.WriteData(workingOrders?.Data, propertiesToDisplay, all);
    }
}
