using TastyTradeApi.Core.Accounts;
using TastyTradeApi.Core.Client;
using TastyTradeApi.Core.NetLiquidatingValueHistory;
using TastyTradeApi.Core.Session;

namespace TastyTradeApi.Core;

public class TastyTrade
{
    private ApiClient _apiClient;

    public TastyTrade(string sessionToken) : this(false, sessionToken)
    { }

    public TastyTrade(bool isCert) : this(isCert, null)
    { }

    public TastyTrade(bool isCert = false, string? sessionToken = null)
    {
        _apiClient = new ApiClient(isCert, sessionToken);

        AccountService = new AccountService(_apiClient);
        NetLiquidatingValueHistoryService = new NetLiquidatingValueHistoryService(_apiClient);
        SessionService = new SessionService(_apiClient);
    }

    public AccountService AccountService { get; set; }
    public NetLiquidatingValueHistoryService NetLiquidatingValueHistoryService { get; set; }
    public SessionService SessionService { get; init; }
}


