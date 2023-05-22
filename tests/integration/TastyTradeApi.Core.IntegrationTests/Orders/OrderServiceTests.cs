namespace TastyTradeApi.Core.IntegrationTests.Orders;

public class OrderServiceTests
{
    [Fact]
    public async Task GetLiveOrders_ReturnsOrders()
    {
        var client = new TastyTrade(true);
        await client.SessionService.Login(MockData.Username, MockData.Password);
        var accountNumber = (await client.AccountService.GetAccounts())?.Data.Items.First().Account.AccountNumber ?? throw new ArgumentNullException();

        var result = await client.OrderService.GetLiveOrders(accountNumber);

        Assert.NotNull(result);
    }
}