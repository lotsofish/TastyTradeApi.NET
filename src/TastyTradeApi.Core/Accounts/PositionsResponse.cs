namespace TastyTradeApi.Core.Accounts;
public record PositionsResponse(
    string AccountNumber,
    string Symbol,
    string InstrumentType,
    string UnderlyingSymbol,
    int Quantity,
    string QuantityDirection,
    string ClosePrice,
    string AverageOpenPrice,
    string AverageYearlyMarketClosePrice,
    string AverageDailyMarketClosePrice,
    int Multiplier,
    string CostEffect,
    bool IsSuppressed,
    bool IsFrozen,
    int RestrictedQuantity,
    DateTime ExpiresAt,
    string RealizedDayGain,
    string RealizedDayGainEffect,
    DateOnly RealizedDayGainDate,
    string RealizedToday,
    string RealizedTodayEffect,
    string RealizedTodayDate,
    DateTime CreatedAt,
    DateTime UpdatedAt);