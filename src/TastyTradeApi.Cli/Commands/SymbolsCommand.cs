namespace TastyTradeApi.Cli.Commands;

internal class SymbolsCommand : AuthenticatedCommandBase
{
    internal SymbolsCommand() : base("symbols", "Search and view symbol information")
    {
        AddCommand(new SymbolsSearchCommand());
    }
}
