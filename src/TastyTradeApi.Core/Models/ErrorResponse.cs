namespace TastyTradeApi.Core.Models;

public record ErrorResponse(Error Error);
public record Error(string Code, string Message);
