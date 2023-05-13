using System.CommandLine;
using System.Text.Json;
using TastyTradeApi.Cli.Models;
using TastyTradeApi.Core;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Cli.Commands;

public class LoginCommand : Command
{
    private const string SESSION_FILE = "session.dat";

    private Argument<string> _usernameArgument = new Argument<string>("username", "TastyTrade Username");
    private Argument<string> _passwordArgument = new Argument<string>("password", "TastyTrade Password");
    private Option<bool> _isCertOption = new Option<bool>("--is-cert", () => false, "If True, use cert environment. Defaults to False");

    public LoginCommand() : base("login", "Login to TastyTrade")
    {
        Add(_usernameArgument);
        Add(_passwordArgument);
        Add(_isCertOption);

        this.SetHandler(HandleCommand, _usernameArgument, _passwordArgument, _isCertOption);
    }

    private static async Task HandleCommand(string username, string password, bool isCert)
    {
        Console.WriteLine("Logging in to TastyTrade...");
        try
        {
            var client = new TastyTrade(isCert);
            var loginResponse = await client.SessionService.Login(username, password);

            if (loginResponse?.Data != null)
            {
                var sessionModel = new SessionModel(loginResponse.Data.SessionToken, isCert);
                using var fileStream = File.Create(SESSION_FILE);
                JsonSerializer.Serialize(fileStream, sessionModel);
                fileStream.Close();
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