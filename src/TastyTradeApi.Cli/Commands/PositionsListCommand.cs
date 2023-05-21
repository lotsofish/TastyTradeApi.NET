using System.CommandLine;
using TastyTradeApi.Cli.Utils;
using TastyTradeApi.Core.Accounts;

namespace TastyTradeApi.Cli.Commands;
internal class PositionsListCommand : AuthenticatedCommandBase
{
    private Argument<string> _accountArgument = new Argument<string>("account", "The account number");
    private Option<string?> _underlyingOption = new Option<string?>("--underlying", "Filter positions by underlying");
    private Option<string?> _symbolOption = new Option<string?>("--symbol", $"Filter positions by symbol.{Environment.NewLine}Examples: Stock 'AAPL', OCC Option Symbol 'AAPL 191004P0027500', TW Future Symbol '/ESZ9', TW Future Option Symbol './ESZ9 EW4U9 190927P2975'");
    private Option<InstrumentType?> _instrumentTypeOption = new Option<InstrumentType?>("--instrument-type", "Filter positions by instrument type");
    private Option<bool> _includeClosedPositionsOption = new Option<bool>("--include-closed-positions", "Include closed positions");
    private Option<string?> _futuresCodeOption = new Option<string?>("--futures-code", "Filter positions by futures code. 'ES', 'CL', etc");
    private Option<bool> _includeMarksOption = new Option<bool>("--include-marks", "Include mark prices (decrease performance)");
    private Option<bool> _allOption = new Option<bool>("--all", "Shows all the position properties");
    private List<string> propertiesToDisplay = new() { "Symbol", "InstrumentType", "UnderlyingSymbol", "Quantity", "QuantityDirection", "ClosePrice", "AverageOpenPrice", "ExpiresAt" };

    internal PositionsListCommand() : base("list", "List positions")
    {
        AddArgument(_accountArgument);
        AddOption(_underlyingOption);
        AddOption(_symbolOption);
        AddOption(_instrumentTypeOption);
        AddOption(_includeClosedPositionsOption);
        AddOption(_futuresCodeOption);
        AddOption(_includeMarksOption);
        AddOption(_allOption);

        this.SetHandler(HandleCommand,
                        _accountArgument,
                        _underlyingOption,
                        _symbolOption,
                        _instrumentTypeOption,
                        _includeClosedPositionsOption,
                        _futuresCodeOption,
                        _includeMarksOption,
                        _allOption);
    }

    private async Task HandleCommand(
        string account,
        string? underlying,
        string? symbol,
        InstrumentType? instrumentType,
        bool includeClosedPositions,
        string? futuresCode,
        bool includeMarks,
        bool all)
    {
        var client = GetClient();
        var positions = await client.AccountService.GetPositions(
            account,
            underlying != null ? new List<string>() { underlying } : null,
            symbol,
            instrumentType,
            includeClosedPositions,
            futuresCode,
            null,
            null,
            includeMarks);
        ConsoleWriter.WriteData(positions?.Data, propertiesToDisplay, all);
    }
}