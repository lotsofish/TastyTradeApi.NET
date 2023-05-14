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

    [Fact]
    public async Task GetBalance_ReturnsBalance()
    {
        var client = new TastyTrade(true);
        await client.SessionService.Login(MockData.Username, MockData.Password);
        var accounts = await client.AccountService.GetAccounts() ?? throw new Exception("Accounts not found");

        var balance = await client.AccountService.GetBalance(accounts.Data.Items.First().Account.AccountNumber);

        Assert.NotNull(balance);
    }

    [Fact]
    public async Task GetTradingStatus_ReturnsTradingStatus()
    {
        var client = new TastyTrade(true);
        await client.SessionService.Login(MockData.Username, MockData.Password);
        var accounts = await client.AccountService.GetAccounts() ?? throw new Exception("Accounts not found");

        var tradingStatus = await client.AccountService.GetTradingStatus(accounts.Data.Items.First().Account.AccountNumber);

        Assert.NotNull(tradingStatus);
    }
}
