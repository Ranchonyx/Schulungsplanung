using Schulungsplanung.Interfaces;

namespace Schulungsplanung;

using Properties;

public class Person : IConsoleCreatable<Person>
{
    public StringProperty FirstName { get; set; }
    public StringProperty LastName { get; set; }
    public IntProperty Age { get; set; }

    public Person()
    {
    }

    protected Person(string pFirstName, string pLastName, int pAge)
    {
        FirstName = StringProperty.From("Vorname", pFirstName);
        LastName = StringProperty.From("Nachname", pLastName);
        Age = IntProperty.From("Alter", pAge);
    }

    public static Person FromConsole()
    {
        Console.WriteLine("Vornamen eingeben:");
        string firstName = Console.ReadLine()!;
        Console.WriteLine("Nachnamen eingeben:");
        string lastName = Console.ReadLine()!;
        Console.WriteLine("Alter eingeben:");
        var age = Util.SafeToInt(Console.ReadLine());

        return new Person(firstName, lastName, age.Item1 ?? 0);
    }

    public override string ToString()
    {
        return $"{FirstName}, {LastName}, {Age}";
    }
}