using TastyTradeApi.Core.Client;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Core.Accounts;

public class AccountService
{
    private readonly ApiClient _apiClient;

    public AccountService(ApiClient apiClient)
    {
        _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
    }

    public async Task<ApiResponseWrapper<ItemCollection<AccountContainer>>?> GetAccounts()
    {
        return await _apiClient.Get<ItemCollection<AccountContainer>>("customers/me/accounts");
    }

    public async Task<ApiResponseWrapper<BalancesResponse>?> GetBalance(string accountNumber)
    {
        return await _apiClient.Get<BalancesResponse>($"accounts/{accountNumber}/balances");
    }

    public async Task<ApiResponseWrapper<TradingStatusResponse>?> GetTradingStatus(string accountNumber)
    {
        return await _apiClient.Get<TradingStatusResponse>($"accounts/{accountNumber}/trading-status");
    }

    public async Task<ApiResponseWrapper<ItemCollection<PositionsResponse>>?> GetPositions(
        string accountNumber,
        IList<string>? underlyingSymbols = null,
        string? symbol = null,
        InstrumentType? instrumentType = null,
        bool? includeClosedPositions = null,
        string? futuresProductCode = null,
        IList<string>? partitionKeys = null,
        bool? netPositions = null,
        bool? includeMarks = null)
    {
        List<string> queryString = new();
        if (underlyingSymbols != null) { queryString.Add(string.Join("&", underlyingSymbols.Select(s => $"underlying-symbol[]={s}"))); }
        if (symbol != null) { queryString.Add($"symbol={symbol}"); }
        if (instrumentType != null) { queryString.Add($"instrument-type={instrumentType?.ToApiString()}"); }
        if (includeClosedPositions != null) { queryString.Add($"include-closed-positions={includeClosedPositions?.ToString().ToLowerInvariant()}"); }
        if (futuresProductCode != null) { queryString.Add($"underlying-product-code={futuresProductCode}"); }
        if (partitionKeys != null) { queryString.Add(string.Join("&", partitionKeys.Select(s => $"partition-key[]={s}"))); }
        if (netPositions != null) { queryString.Add($"net-positions={netPositions?.ToString().ToLowerInvariant()}"); }
        if (includeMarks != null) { queryString.Add($"include-marks={includeMarks?.ToString().ToLowerInvariant()}"); }

        return await _apiClient.Get<ItemCollection<PositionsResponse>>($"accounts/{accountNumber}/positions?{string.Join("&", queryString)}");
    }
}