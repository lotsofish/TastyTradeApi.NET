namespace TastyTradeApi.Core.NetLiquidatingValueHistory;

public enum TimeBack
{
    Days1,
    Weeks1,
    Months1,
    Months3,
    Months6,
    Years1,
    All
}

public static class TimeBackExtensions
{
    public static string ToApiString(this TimeBack timeBack)
    {
        return timeBack switch
        {
            TimeBack.Days1 => "1d",
            TimeBack.Weeks1 => "1w",
            TimeBack.Months1 => "1m",
            TimeBack.Months3 => "3m",
            TimeBack.Months6 => "6m",
            TimeBack.Years1 => "1y",
            TimeBack.All => "all",
            _ => throw new ArgumentOutOfRangeException(nameof(timeBack), timeBack, null)
        };

    }
}