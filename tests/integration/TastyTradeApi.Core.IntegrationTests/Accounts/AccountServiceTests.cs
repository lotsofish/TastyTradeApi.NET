namespace TastyTradeApi.Core.IntegrationTests.Accounts;

public class AccountServiceTests
{
    [Fact]
    public async Task GetAccounts_ReturnsAccounts()
    {
        var client = new TastyTrade(true);
        await client.SessionService.Login(MockData.Username, MockData.Password);

        var accounts = await client.AccountService.GetAccounts();

        Assert.NotNull(accounts);

    }
}
