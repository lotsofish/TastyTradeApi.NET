namespace TastyTradeApi.Cli.Commands;

internal class PositionsCommand : AuthenticatedCommandBase
{
    internal PositionsCommand() : base("positions", "Gets information about your account's open positions")
    {
        AddCommand(new PositionsListCommand());
    }
}
