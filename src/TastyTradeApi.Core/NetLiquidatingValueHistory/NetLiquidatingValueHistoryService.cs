using System.Text;
using System.Web;
using TastyTradeApi.Core.Client;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Core.NetLiquidatingValueHistory;

public class NetLiquidatingValueHistoryService
{
    private readonly ApiClient _apiClient;

    public NetLiquidatingValueHistoryService(ApiClient apiClient)
    {
        _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
    }

    public async Task<ApiResponseWrapper<ItemCollection<NetLiquidatingValueHistoryResponse>>?> GetNetLiquidatingValueHistory
        (string accountNumber, TimeBack? timeBack = null, DateTime? startTime = null)
    {
        if (timeBack == null && startTime == null)
        {
            throw new ArgumentNullException("Either timeBack or startTime must be provided");
        }
        if (timeBack != null && startTime != null)
        {
            throw new ArgumentException("Only one of timeBack or startTime may be provided");
        }

        StringBuilder queryString = new();
        if (timeBack != null)
        {
            queryString.Append("time-back=").Append(timeBack.Value.ToApiString());
        }
        if (startTime != null)
        {
            queryString.Append("start-time=").Append(startTime.Value.ToString("s"));
        }

        return await _apiClient.Get<ItemCollection<NetLiquidatingValueHistoryResponse>>($"accounts/{accountNumber}/net-liq/history?{queryString.ToString()}");
    }
}