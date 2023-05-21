namespace TastyTradeApi.Core.Accounts;

public record PositionLimitResponse(
    string AccountNumber,
    int EquityOrderSize,
    int EquityOptionOrderSize,
    int FutureOrderSize,
    int FutureOptionOrderSize,
    int EquityPositionSize,
    int EquityOptionPositionSize,
    int FuturePositionSize,
    int FutureOptionPositionSize
);