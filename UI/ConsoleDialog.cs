namespace Containers.UI;

public class ConsoleDialog
{
    private static string GetStrategy(string dialog)
    {
        string? line;
        do
        {
            Console.Clear();
            Console.Write(dialog);
            line = Console.ReadLine();
            
        } while (line == null);
        return line;
    }

    private static T NumericParseStrategy<T>(string dialog, bool isNegative, Func<string, T> parseFunc) 
        where T : IComparable<T>
    {
        while (true)
        {
            try
            {
                var parsedResult = parseFunc(GetStrategy(dialog));
                if (!isNegative && parsedResult.CompareTo(default) < 0) continue;
                return parsedResult;
            }
            catch (Exception exc) when (exc is FormatException or ArgumentNullException) {}
        }
    }
    
    public static string GetStringStrategy(string dialog) => GetStrategy(dialog);

    
    public static int GetIntStrategy(string dialog, bool isNegative) => NumericParseStrategy(
        dialog, isNegative, int.Parse);

    public static double GetDoubleStrategy(string dialog, bool isNegative) => NumericParseStrategy(
        dialog, isNegative, double.Parse);
}