using System.CommandLine;
using System.CommandLine.Parsing;
using TastyTradeApi.Cli.Commands;

var rootCommand = new RootCommand("TastyTrade API CLI");
rootCommand.AddCommand(new LoginCommand());

return await rootCommand.InvokeAsync(args);