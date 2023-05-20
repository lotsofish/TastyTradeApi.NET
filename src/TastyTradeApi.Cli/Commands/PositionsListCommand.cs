using System.CommandLine;
using System.Linq;
using TastyTradeApi.Cli.Utils;
using TastyTradeApi.Core.Accounts;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Cli.Commands;
public class PositionsListCommand : AuthenticatedCommandBase
{
    private Argument<string> _accountArgument = new Argument<string>("account", "The account number");
    private Option<string?> _underlyingOption = new Option<string?>("--underlying", "Filter positions by underlying");
    private Option<bool> _allOption = new Option<bool>("--all", "Shows all the position properties");
    private List<string> propertiesToDisplay = new() { "Symbol", "InstrumentType", "UnderlyingSymbol", "Quantity", "QuantityDirection", "ClosePrice", "AverageOpenPrice", "ExpiresAt" };

    public PositionsListCommand() : base("list", "List positions")
    {
        AddArgument(_accountArgument);
        AddOption(_underlyingOption);
        AddOption(_allOption);

        this.SetHandler(HandleCommand, _accountArgument, _underlyingOption, _allOption);
    }

    private async Task HandleCommand(string account, string? underlying, bool all)
    {
        var client = GetClient();
        var positions = await client.AccountService.GetPositions(account);
        ConsoleWriter.WriteData(FilterUnderlying(positions?.Data, underlying), propertiesToDisplay, all);
    }

    private ItemCollection<PositionsResponse>? FilterUnderlying(ItemCollection<PositionsResponse>? positionCollection, string? underlying)
    {
        if (positionCollection == null) { return null; }

        var filteredItems = positionCollection.Items.Where(p => underlying == null || p.UnderlyingSymbol.ToUpperInvariant() == underlying.ToUpperInvariant());
        return new ItemCollection<PositionsResponse>(filteredItems.ToList());
    }
}