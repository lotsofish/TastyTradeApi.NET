namespace TastyTradeApi.Core.Models;

public record ApiResponseWrapper<T>(T Data, string Context);