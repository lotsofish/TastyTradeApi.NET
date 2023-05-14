using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using TastyTradeApi.Cli.Commands;
using TastyTradeApi.Core.Models;

var rootCommand = new RootCommand("TastyTrade API CLI");
rootCommand.AddCommand(new LoginCommand());
rootCommand.AddCommand(new AccountsCommand());
rootCommand.AddCommand(new BalanceCommand());

var builder = new CommandLineBuilder(rootCommand);
builder.UseDefaults();
builder.UseExceptionHandler(async (ex, code) =>
{
    if (ex is TastyTradeApiException ttex)
    {
        var errorResponse = await ttex.GetErrorResponse();
        Console.WriteLine("An error occurred. Here is what the API is telling us:");
        Console.WriteLine($"  Error code: {errorResponse?.Error.Code}");
        Console.WriteLine($"  Error message: {errorResponse?.Error.Message}");
        Console.WriteLine();
        Console.WriteLine("Account numbers are case-sensitive. ");
    }
    else
    {
        Console.WriteLine("An unexpected error occurred.");
        Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
    }
    Environment.Exit(1);
});

var parser = builder.Build();

return await parser.InvokeAsync(args);