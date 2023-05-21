using System.CommandLine;
using System.Reflection;
using TastyTradeApi.Cli.Sessions;
using TastyTradeApi.Core;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Cli.Commands;

internal class LoginCommand : Command
{
    private const string SESSION_FILE = "session.dat";

    private Option<string?> _usernameArgument = new Option<string?>("username", "TastyTrade Username");
    private Option<string?> _passwordArgument = new Option<string?>("password", "TastyTrade Password");
    private Option<bool> _useCertOption = new Option<bool>("--use-cert", () => false, "Use the sandbox certification environment. This requires a TastyTrade Developer account and a sandbox certification environment account. See https://support.tastyworks.com/support/solutions/articles/43000700385-tastytrade-open-api for details.");

    internal LoginCommand() : base("login", "Login to TastyTrade")
    {
        Add(_usernameArgument);
        Add(_passwordArgument);
        Add(_useCertOption);

        this.SetHandler(HandleCommand, _usernameArgument, _passwordArgument, _useCertOption);
    }

    private static async Task HandleCommand(string? username, string? password, bool useCert)
    {
        Console.WriteLine($"Enter your username and password to create a TastyTrade Session. Use `{Assembly.GetExecutingAssembly().GetName().Name} login -h` for additional login options.");
        if (useCert) { Console.WriteLine("Using sandbox certification environment"); }

        while (string.IsNullOrEmpty(username))
        {
            Console.Write("Username: ");
            username = Console.ReadLine();
        }

        while (string.IsNullOrEmpty(password))
        {
            Console.Write("Password: ");
            password = Console.ReadLine();
        }

        Console.WriteLine("Logging in to TastyTrade...");
        try
        {
            var client = new TastyTrade(useCert);
            var loginResponse = await client.SessionService.Login(username, password);

            if (loginResponse?.Data != null)
            {
                var sessionModel = new SessionModel(loginResponse.Data.SessionToken, useCert);
                new SessionFileService().WriteSession(sessionModel);
                Console.WriteLine("Login successful, session stored");
            }
            else
            {
                Console.WriteLine("Unknown error");
                Environment.Exit(1);
            }
        }
        catch (TastyTradeApiException ex)
        {
            var errorResponse = await ex.GetErrorResponse();
            Console.WriteLine("Login failed ({0}): {1}", errorResponse?.Error.Code, errorResponse?.Error.Message);
            new SessionFileService().RemoveSessionFile();
            Environment.Exit(1);
        }
    }
}