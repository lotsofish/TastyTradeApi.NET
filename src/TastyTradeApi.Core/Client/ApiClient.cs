using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Core.Client;

public class ApiClient
{
    private readonly HttpClient _httpClient = new();
    public static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = new DashedJsonNamingPolicy.DashedJsonNamingPolicy()
    };

    public ApiClient(string baseAddress) : this(baseAddress, null)
    { }

    public ApiClient(string baseAddress, string? sessionToken)
    {
        _httpClient.BaseAddress = new Uri(baseAddress);
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "TastyTradeApi.NET");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        if (!string.IsNullOrEmpty(sessionToken))
        {
            SetSessionToken(sessionToken);
        }
    }

    public void SetSessionToken(string token)
    {
        _httpClient.DefaultRequestHeaders.Add("Authorization", token);
    }

    public async Task<ApiResponseWrapper<T>?> Get<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            throw new TastyTradeApiException(response);
        }

        var responseString = (await response.Content.ReadAsStringAsync()) ?? throw new HttpRequestException(response.ReasonPhrase, null, response.StatusCode);
        return JsonSerializer.Deserialize<ApiResponseWrapper<T>>(responseString, JsonSerializerOptions);
    }

    public async Task<ApiResponseWrapper<T>?> Post<T>(string url, object? content = null)
    {
        var response = await _httpClient.PostAsync(url, GetStringContent(content));
        if (!response.IsSuccessStatusCode)
        {
            throw new TastyTradeApiException(response);
        }

        var responseString = await response.Content.ReadAsStringAsync() ?? throw new HttpRequestException(response.ReasonPhrase, null, response.StatusCode);
        return JsonSerializer.Deserialize<ApiResponseWrapper<T>>(responseString, JsonSerializerOptions);
    }

    public async Task<bool> Delete(string url)
    {
        var response = await _httpClient.DeleteAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            throw new TastyTradeApiException(response);
        }

        return response.IsSuccessStatusCode;
    }


    private StringContent? GetStringContent(object? content)
    {
        return content == null ? null :
            new StringContent(JsonSerializer.Serialize(content, JsonSerializerOptions), System.Text.Encoding.UTF8, "application/json");
    }

}
