using System.Text;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Cli.Utils;

public static class ConsoleWriter
{
    public static void WriteData<T>(ItemCollection<T>? data, IList<string>? propertiesToDisplay = null, bool all = true)
    {
        if (data == null) return;

        foreach (var item in data.Items)
        {
            WriteData(item, propertiesToDisplay, all);
            Console.WriteLine();
        }

    }

    public static void WriteData<T>(T? data, IList<string>? propertiesToDisplay = null, bool all = true)
    {
        if (data == null) return;

        StringBuilder formattedData = new();

        var properties = data.GetType().GetProperties();
        foreach (var property in properties)
        {
            if (property.PropertyType.Namespace?.Contains("TastyTradeApi.Core") ?? false)
            {
                WriteData(property.GetValue(data), propertiesToDisplay, all);
            }
            else if ((propertiesToDisplay != null && propertiesToDisplay.Contains(property.Name)) || all)
            {
                formattedData.AppendLine($"{property.Name}: {property.GetValue(data)}");
            }
        }

        Console.Write(formattedData.ToString());
    }
}
