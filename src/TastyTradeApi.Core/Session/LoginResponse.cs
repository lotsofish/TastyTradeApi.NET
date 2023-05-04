namespace TastyTradeApi.Core.Session;

public record LoginResponse(User User, string SessionToken, string? RememberToken);
