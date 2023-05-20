namespace TastyTradeApi.Cli.Commands;

public class PositionsCommand : AuthenticatedCommandBase
{
    public PositionsCommand() : base("positions", "Gets information about your account's open positions")
    {
        AddCommand(new PositionsListCommand());
    }
}
