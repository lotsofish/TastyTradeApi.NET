namespace TastyTradeApi.Core.Accounts;

public record AccountContainer(Account Account, string AuthorityLevel);
public record Account(
    string AccountNumber,
    DateTime OpenedAt,
    string Nickname,
    string AccountTypeName,
    bool DayTraderStatus,
    bool IsClosed,
    bool IsFirmError,
    bool IsFirmProprietary,
    bool IsFuturesApproved,
    bool IsTestDrive,
    string MarginOrCash,
    bool IsForeign,
    string InvestmentObjective,
    string SuitableOptionsLevel,
    DateTime CreatedAt);