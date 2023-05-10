using TastyTradeApi.Core.NetLiquidatingValueHistory;

namespace TastyTradeApi.Core.IntegrationTests.NetLiquidatingValueHistory;

public class NetLiquidatingValueHistoryServiceTests
{
    [Fact]
    public async Task GetNetLiquidatingValueHistoryAsync_ShouldReturnNetLiquidatingValueHistory()
    {
        var client = new TastyTrade();
        await client.SessionService.Login(MockData.Username, MockData.Password);
        var accountNumber = (await client.AccountService.GetAccounts())?.Data.Items.First().Account.AccountNumber ?? throw new ArgumentNullException();

        var result = await client.NetLiquidatingValueHistoryService.GetNetLiquidatingValueHistory(accountNumber, TimeBack.Months1);

        Assert.NotNull(result);
    }
}