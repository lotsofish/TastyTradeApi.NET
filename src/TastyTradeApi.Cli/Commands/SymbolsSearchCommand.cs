using System.CommandLine;
using TastyTradeApi.Cli.Utils;

namespace TastyTradeApi.Cli.Commands;

public class SymbolsSearchCommand : AuthenticatedCommandBase
{
    Argument<string> _searchArgument = new("search", "Search string");

    public SymbolsSearchCommand() : base("search", "Search for symbols (Use quotes for phrases, 'proshares ultrapro')")
    {
        AddArgument(_searchArgument);

        this.SetHandler(HandleCommand, _searchArgument);
    }

    private async Task HandleCommand(string search)
    {
        var client = GetClient();
        var symbolResults = await client.InstrumentService.SymbolSearch(search);
        ConsoleWriter.WriteData(symbolResults?.Data);
    }
}
