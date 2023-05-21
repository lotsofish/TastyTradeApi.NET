using TastyTradeApi.Core.Client;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Core.Instruments;

public class InstrumentService
{
    private readonly ApiClient _apiClient;

    public InstrumentService(ApiClient apiClient)
    {
        _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
    }

    public async Task<ApiResponseWrapper<ItemCollection<SearchResult>>?> SymbolSearch(string searchString)
    {
        return await _apiClient.Get<ItemCollection<SearchResult>>($"/symbols/search/{searchString}");
    }


}