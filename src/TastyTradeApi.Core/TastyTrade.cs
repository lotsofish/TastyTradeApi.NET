using TastyTradeApi.Core.Accounts;
using TastyTradeApi.Core.Client;
using TastyTradeApi.Core.Session;

namespace TastyTradeApi.Core;

public class TastyTrade
{
    private const string BaseUrl = "https://api.tastyworks.com";
    private const string BaseUrl_Cert = "https://api.cert.tastyworks.com";

    private ApiClient _apiClient;

    public TastyTrade(bool isCert = false)
    {
        _apiClient = new ApiClient(isCert ? BaseUrl_Cert : BaseUrl);

        AccountService = new AccountService(_apiClient);
        SessionService = new SessionService(_apiClient);
    }

    public AccountService AccountService { get; set; }
    public SessionService SessionService { get; init; }
}


