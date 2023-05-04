using TastyTradeApi.Core.Client;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Core.Accounts;

public class AccountService
{
    private readonly ApiClient _apiClient;

    public AccountService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<ApiResponseWrapper<ItemCollection<AccountContainer>>?> GetAccounts()
    {
        return await _apiClient.Get<ItemCollection<AccountContainer>>("customers/me/accounts");
    }
}