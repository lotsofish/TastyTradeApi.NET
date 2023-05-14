using System.Text;

namespace TastyTradeApi.Cli.Utils;

public static class ConsoleWriter
{
    public static void WriteData<T>(T? data, IList<string> propertiesToDisplay, bool all = false)
    {
        if (data == null) return;

        StringBuilder formattedData = new();

        var properties = data.GetType().GetProperties();
        foreach (var property in properties)
        {
            if (propertiesToDisplay.Contains(property.Name))
            {
                formattedData.AppendLine($"{property.Name}: {property.GetValue(data)}");
            }
        }

        if (all)
        {
            foreach (var property in properties)
            {
                if (!propertiesToDisplay.Contains(property.Name))
                {
                    formattedData.AppendLine($"{property.Name}: {property.GetValue(data)}");
                }
            }
        }

        Console.WriteLine(formattedData.ToString());
    }
}
