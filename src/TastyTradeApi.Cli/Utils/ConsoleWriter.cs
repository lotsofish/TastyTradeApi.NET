using System.Text;
using System.Text.RegularExpressions;
using TastyTradeApi.Core.Models;

namespace TastyTradeApi.Cli.Utils;

internal static class ConsoleWriter
{
    internal static void WriteData<T>(ItemCollection<T>? data, IList<string>? propertiesToDisplay = null, bool all = true)
    {
        if (data == null) return;

        foreach (var item in data.Items)
        {
            WriteData(item, propertiesToDisplay, all);
            Console.WriteLine();
        }

    }

    internal static void WriteData<T>(T? data, IList<string>? propertiesToDisplay = null, bool all = true)
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
                formattedData.AppendLine($"{FormatName(property.Name)}: {property.GetValue(data)}");
            }
        }

        Console.Write(formattedData.ToString());
    }

    private static string FormatName(string name)
    {
        return new Regex("(?![A-Z])(.*?)([A-Z])").Replace(name, "$1 $2");
    }
}
