using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Core.IntegrationTests.Session;

public class SessionServiceTests
{
    [Fact]
    public async Task Login()
    {
        var client = new TastyTrade(true);

        var response = await client.SessionService.Login(MockData.Username, MockData.Password);

        Assert.NotNull(response);
        Assert.NotNull(response.Data.SessionToken);
    }

    [Fact]
    public async Task Validate()
    {
        var client = new TastyTrade(true);

        await client.SessionService.Login(MockData.Username, MockData.Password);

        var response = await client.SessionService.Validate();

        Assert.NotNull(response);
        Assert.NotNull(response.Data.Email);
    }

    [Fact]
    public async Task Logout()
    {
        var client = new TastyTrade(true);

        await client.SessionService.Login(MockData.Username, MockData.Password);
        var response = await client.SessionService.Logout();

        var validateFunction = async () => await client.SessionService.Validate();

        Assert.True(response);
        await Assert.ThrowsAsync<TastyTradeApiException>(validateFunction);
    }
}