using System.Text.Json.Serialization;
using TastyTradeApi.Core.Utils;

namespace TastyTradeApi.Core.NetLiquidatingValueHistory;

public record NetLiquidatingValueHistoryResponse(
    string Open,
    string High,
    string Low,
    string Close,
    string PendingCashOpen,
    string PendingCashHigh,
    string PendingCashLow,
    string PendingCashClose,
    string TotalOpen,
    string TotalHigh,
    string TotalLow,
    string TotalClose,
    [property:JsonConverter(typeof(DateTimeParseConverter))]
    DateTime Time
);