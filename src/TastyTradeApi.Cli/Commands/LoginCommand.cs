using System.CommandLine;
using TastyTradeApi.Cli.Sessions;
using TastyTradeApi.Core;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Cli.Commands;

public class LoginCommand : Command
{
    private const string SESSION_FILE = "session.dat";

    private Option<string?> _usernameArgument = new Option<string?>("username", "TastyTrade Username");
    private Option<string?> _passwordArgument = new Option<string?>("password", "TastyTrade Password");
    private Option<bool> _isCertOption = new Option<bool>("--is-cert", () => false, "Use the sandbox certification environment. This requires a TastyTrade Developer account and a sandbox certification environment account. See https://support.tastyworks.com/support/solutions/articles/43000700385-tastytrade-open-api for details.");

    public LoginCommand() : base("login", "Login to TastyTrade")
    {
        Add(_usernameArgument);
        Add(_passwordArgument);
        Add(_isCertOption);

        this.SetHandler(HandleCommand, _usernameArgument, _passwordArgument, _isCertOption);
    }

    private static async Task HandleCommand(string? username, string? password, bool isCert)
    {
        if (isCert) { Console.WriteLine("Using sandbox certification environment"); }

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
            var client = new TastyTrade(isCert);
            var loginResponse = await client.SessionService.Login(username, password);

            if (loginResponse?.Data != null)
            {
                var sessionModel = new SessionModel(loginResponse.Data.SessionToken, isCert);
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
            if (File.Exists(SESSION_FILE))
            {
                File.Delete(SESSION_FILE);
            }
            Environment.Exit(1);
        }
    }
}