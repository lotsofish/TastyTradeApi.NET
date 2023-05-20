namespace TastyTradeApi.Core.Accounts;

public enum InstrumentType
{
    Bond,
    Cryptocurrency,
    CurrencyPair,
    Equity,
    EquityOffering,
    EquityOption,
    Future,
    FutureOption,
    Index,
    Unknown,
    Warrant
}

public static class InstrumentTypeExtensions
{
    public static string ToApiString(this InstrumentType instrumentType)
    {
        return instrumentType switch
        {
            InstrumentType.Bond => "Bond",
            InstrumentType.Cryptocurrency => "Cryptocurrency",
            InstrumentType.CurrencyPair => "Currency Pair",
            InstrumentType.Equity => "Equity",
            InstrumentType.EquityOffering => "Equity Offering",
            InstrumentType.EquityOption => "Equity Option",
            InstrumentType.Future => "Future",
            InstrumentType.FutureOption => "Future Option",
            InstrumentType.Index => "Index",
            InstrumentType.Unknown => "Unknown",
            InstrumentType.Warrant => "Warrant",
            _ => throw new ArgumentOutOfRangeException(nameof(instrumentType), instrumentType, null)
        };
    }

}