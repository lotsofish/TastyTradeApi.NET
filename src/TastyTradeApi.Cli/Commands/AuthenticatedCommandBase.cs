using System.CommandLine;
using System.Reflection;
using TastyTradeApi.Cli.Sessions;
using TastyTradeApi.Core;
using TastyTradeApi.Core.Session;

namespace TastyTradeApi.Cli.Commands;

public class AuthenticatedCommandBase : Command
{
    private TastyTrade? _client;
    protected SessionFileService SessionFileService { get; } = new();
    protected User? User { get; set; }

    public AuthenticatedCommandBase(string name, string? description = null) : base(name, description)
    { }

    protected TastyTrade GetClient()
    {
        if (_client != null) { return _client; }

        var session = SessionFileService.GetSession();
        if (session != null)
        {
            _client = new TastyTrade(session.IsCert, session.SessionToken);
        }

        if (_client != null)
        {
            User = _client.SessionService.Validate().GetAwaiter().GetResult()?.Data;
        }

        // If User is not set, then we don't have a valid session.
        // Display a message and exit.
        if (User == null || _client == null)
        {
            Console.WriteLine($"Session not found or timed out. Please login using `{Assembly.GetExecutingAssembly().GetName().Name} login`.");
            Environment.Exit(1);
        }

        return _client;
    }
}
