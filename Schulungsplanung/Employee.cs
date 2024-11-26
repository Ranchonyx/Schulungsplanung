namespace Schulungsplanung;

public class Employee : Person, IDescriptionPrintable, IHasProperties
{
    public Employee(string pFirstName, string pLastName, int pAge) : base(pFirstName, pLastName, pAge)
    {
    }

    public void PrintDescription()
    {
        Console.WriteLine($"(Angestellter) {LastName}, {FirstName}, {Age}");
    }

    public List<object> GetProperties()
    {
        return [FirstName, LastName, Age];
    }
}