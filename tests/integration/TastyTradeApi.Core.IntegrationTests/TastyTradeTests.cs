namespace TastyTradeApi.Core.IntegrationTests;

public class TastyTradeTests
{
    [Fact]
    public void TastyTrade_UseCert()
    {
        bool useCert = true;

        var client = new TastyTrade(useCert);

        Assert.NotNull(client);
    }

    [Fact]
    public async Task TastyTrade_UseCert_SessionToken()
    {
        bool useCert = true;
        var client = new TastyTrade(useCert);
        var session = await client.SessionService.Login(MockData.Username, MockData.Password);

        var client2 = new TastyTrade(useCert, session?.Data.SessionToken);
        var user = await client2.SessionService.Validate();

        Assert.NotNull(user);
    }

    // These use cases don't make for good integration tests because they would default to the production api.
    // public void TastyTrade_Default() { }
    // public void TastyTrade_SessionToken() { }

}
