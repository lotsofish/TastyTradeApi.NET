namespace TastyTradeApi.Core.IntegrationTests;

public class TastyTradeTests
{
    [Fact]
    public void TastyTrade_IsCert()
    {
        bool isCert = true;

        var client = new TastyTrade(isCert);

        Assert.NotNull(client);
    }

    [Fact]
    public async Task TastyTrade_IsCert_SessionToken()
    {
        bool isCert = true;
        var client = new TastyTrade(isCert);
        var session = await client.SessionService.Login(MockData.Username, MockData.Password);

        var client2 = new TastyTrade(isCert, session?.Data.SessionToken);
        var user = await client2.SessionService.Validate();

        Assert.NotNull(user);
    }

    // These use cases don't make for good integration tests because they would default to the production api.
    // public void TastyTrade_Default() { }
    // public void TastyTrade_SessionToken() { }

}
