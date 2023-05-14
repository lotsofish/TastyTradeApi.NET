using System.Text.Json;
using TastyTradeApi.Core;

namespace TastyTradeApi.Cli.Sessions;

public class SessionFileService
{
    private const string SESSION_FILE = "session.dat";
    internal SessionModel? GetSession()
    {
        if (!File.Exists(SESSION_FILE))
        {
            return null;
        }

        using var fileStream = File.OpenRead(SESSION_FILE);
        var session = JsonSerializer.Deserialize<SessionModel>(fileStream);
        fileStream.Close();
        return session;
    }

    internal void WriteSession(SessionModel sessionModel)
    {
        using var fileStream = File.Create(SESSION_FILE);
        JsonSerializer.Serialize(fileStream, sessionModel);
        fileStream.Close();
    }
}
