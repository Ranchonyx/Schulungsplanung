namespace Schulungsplanung;

public enum YNCResult
{
    Yes = 0,
    No = 1,
    Cancel = 2
}

public static class Util
{
    public static (string?, bool) SafeToString(string? pString)
    {
        if (pString == null)
            return (null, true);

        if (pString.Length > 0xffff)
            return (null, true);

        return (pString!, false);
    }

    public static (int?, bool) SafeToInt(string? pString)
    {
        try
        {
            return (Convert.ToInt32(pString), false);
        }
        catch (Exception ex)
        {
            switch (ex)
            {
                case FormatException exception:
                    Console.WriteLine($"Der eingegebene Wert '{pString}' ist in einem ungültigen Format !");
                    break;
                case OverflowException exception:
                    Console.WriteLine($"Der eingegebene Wert '{pString}' ist größer als 2^32 !");
                    break;
            }

            return (null, true);
        }
    }

    public static YNCResult YesNoCancel(string message = "")
    {
        Console.WriteLine($"{message} J[a] / N[ein] / A[bbruch]");

        while (true)
        {
            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.A:
                    return YNCResult.Cancel;
                case ConsoleKey.N:
                    return YNCResult.No;
                case ConsoleKey.J:
                    return YNCResult.Yes;
            }
        }
    }

    public static int Choice(string option1, string option2, string option3, string message = "")
    {
        Console.WriteLine($"{message}   {option1} / {option2} / {option3}");

        string line = Console.ReadLine();
        if (line == option1)
            return 0;
        if (line == option2)
            return 1;
        if (line == option3)
            return 2;

        return -1;
    }

    public static bool Ask(string message = "")
    {
        Console.WriteLine(message);

        while (true)
        {
            var key = Console.ReadKey(intercept: true).Key;
            if (key == ConsoleKey.Enter || key == ConsoleKey.Y)
                return true;

            if (key == ConsoleKey.Escape || key == ConsoleKey.N)
                return false;
        }
    }

    public static void PrintList<T>(List<T> selection)
    {
        for (int i = 0; i < selection.Count; i++)
        {
            var p = selection.ElementAt(i);
            Console.WriteLine($"{i}: {p}");
        }
    }
}