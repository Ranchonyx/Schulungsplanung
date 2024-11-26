namespace Schulungsplanung;

public static class Util
{
    public static int? SafeToInt(string pString)
    {
        try
        {
            return Convert.ToInt32(pString);
        }
        catch(Exception ex)
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
            return null;
        }
    }
    
    public static void
}