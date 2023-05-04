using TastyTradeApi.Core.Client;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Core.Session;

public class SessionService
{
    private ApiClient _apiClient;

    public SessionService(ApiClient apiClient)
    {
        _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
    }

    public async Task<ApiResponseWrapper<LoginResponse>?> Login(string login, string password, bool rememberMe = false)
    {
        var loginResponse = await _apiClient.Post<LoginResponse>("sessions", new { login, password, rememberMe });
        if (loginResponse != null)
        {
            _apiClient.SetAuthorizationToken(loginResponse.Data.SessionToken);
        }
        return loginResponse;
    }

    public async Task<ApiResponseWrapper<LoginResponse>?> LoginWithRememberToken(string login, string rememberToken, bool rememberMe = false)
    {
        var loginResponse = await _apiClient.Post<LoginResponse>("sessions", new { login, rememberToken, rememberMe });
        if (loginResponse != null)
        {
            _apiClient.SetAuthorizationToken(loginResponse.Data.SessionToken);
        }
        return loginResponse;
    }

    public async Task<ApiResponseWrapper<User>?> Validate()
    {
        return await _apiClient.Post<User>("sessions/validate");

    }

    public async Task<bool> Logout()
    {
        return await _apiClient.Delete("sessions");
    }
}

