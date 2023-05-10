namespace TastyTradeApi.Core.NetLiquidatingValueHistory;

public record NetLiquidatingValueResponse(
    string AccountNumber,
    string CashBalanceValue,
    string PendingCash,
    string PendingCashEffect,
    string LongEquityValue,
    string ShortEquityValue,
    string LongDerivativeVale,
    string ShortDerivativeValue,
    string LongFuturesValue,
    string ShortFuturesValue,
    string LongFuturesDerivativeValue,
    string ShortFuturesDerivativeValue,
    string LongCryptocurrencyValue,
    string ShortCryptocurrencyValue,
    string LongBondValue,
    string TotalNetLiqValue,
    DateTime UpdatedAt);
