namespace TastyTradeApi.Cli.Commands;

public class SymbolsCommand : AuthenticatedCommandBase
{
    public SymbolsCommand() : base("symbols", "Search and view symbol information")
    {
        AddCommand(new SymbolsSearchCommand());
    }
}
