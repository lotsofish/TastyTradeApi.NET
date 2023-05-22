using System.CommandLine;

namespace TastyTradeApi.Cli.Commands;

internal class OrdersListCommand : AuthenticatedCommandBase
{
    internal OrdersListCommand(Argument<string> accountArgument) : base("list", "List your orders")
    {
        AddCommand(new OrdersListWorkingCommand(accountArgument));

        // this.SetHandler(HandleCommand, accountArgument);
    }

    private async Task HandleCommand(string account)
    {
        // TODO: implement
        await Task.CompletedTask;
    }
}
