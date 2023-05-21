namespace TastyTradeApi.Core.IntegrationTests.Instruments;

public class InstrumentServiceTests
{
    [Fact]
    public async Task SymbolSearch_ShouldReturnResults()
    {
        var client = new TastyTrade(true);
        await client.SessionService.Login(MockData.Username, MockData.Password);

        var result = await client.InstrumentService.SymbolSearch("AAPL");

        Assert.NotNull(result);
        Assert.Collection(result.Data.Items, x => Assert.Equal("AAPL", x.Symbol));
    }
}