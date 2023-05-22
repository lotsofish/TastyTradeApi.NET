using System.CommandLine;

namespace TastyTradeApi.Cli.Commands;

internal class OrdersCommand : Command
{
    private Argument<string> _accountArgument = new Argument<string>("account", "The account number");

    internal OrdersCommand() : base("orders", "Manage orders")
    {
        AddArgument(_accountArgument);
        AddCommand(new OrdersListCommand(_accountArgument));
    }
}





