using System.Text.Json;
using TastyTradeApi.Core.Client;

namespace TastyTradeApi.Core.Models;

public class TastyTradeApiException : Exception
{
    public HttpResponseMessage HttpResponseMessage { get; init; }

    public TastyTradeApiException(HttpResponseMessage response)
    {
        HttpResponseMessage = response;
    }

    public async Task<ErrorResponse?> GetErrorResponse()
    {
        var responseString = await HttpResponseMessage.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ErrorResponse>(responseString, ApiClient.JsonSerializerOptions);
    }
}
