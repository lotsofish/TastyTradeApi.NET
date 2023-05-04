namespace TastyTradeApi.Core.Session;

public record User(string Email, string Username, string ExternalId, int? Id);