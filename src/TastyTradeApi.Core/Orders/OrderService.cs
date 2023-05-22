using TastyTradeApi.Core.Client;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Core.Orders;

public class OrderService
{
    private readonly ApiClient _apiClient;

    public OrderService(ApiClient apiClient)
    {
        _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
    }

    public async Task<ApiResponseWrapper<ItemCollection<Order>>?> GetLiveOrders(string accountNumber)
    {
        return await _apiClient.Get<ItemCollection<Order>>($"/accounts/{accountNumber}/orders/live");
    }
}
