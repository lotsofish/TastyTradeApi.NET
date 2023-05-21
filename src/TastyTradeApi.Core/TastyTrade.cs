using TastyTradeApi.Core.Accounts;
using TastyTradeApi.Core.Client;
using TastyTradeApi.Core.Instruments;
using TastyTradeApi.Core.NetLiquidatingValueHistory;
using TastyTradeApi.Core.Session;

namespace TastyTradeApi.Core;

public class TastyTrade
{
    private ApiClient _apiClient;

    public AccountService AccountService { get; init; }
    public InstrumentService InstrumentService { get; init; }
    public NetLiquidatingValueHistoryService NetLiquidatingValueHistoryService { get; init; }
    public SessionService SessionService { get; init; }

    public TastyTrade(string sessionToken) : this(false, sessionToken)
    { }

    public TastyTrade(bool isCert) : this(isCert, null)
    { }

    public TastyTrade(bool isCert = false, string? sessionToken = null)
    {
        _apiClient = new ApiClient(isCert, sessionToken);

        AccountService = new(_apiClient);
        InstrumentService = new(_apiClient);
        NetLiquidatingValueHistoryService = new(_apiClient);
        SessionService = new(_apiClient);
    }
}


