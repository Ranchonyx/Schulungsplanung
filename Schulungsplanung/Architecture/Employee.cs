namespace Schulungsplanung;

using Interfaces;

public class Employee : Person, IDescriptionPrintable, IEditable, IConsoleCreatable<Employee>
{
    public Employee() : base()
    {
        
    }
    public Employee(string pFirstName, string pLastName, int pAge) : base(pFirstName, pLastName, pAge)
    {
    }

    public void PrintDescription()
    {
        Console.WriteLine($"(Angestellter) {LastName}, {FirstName}, {Age}");
    }

    public void Edit()
    {
        throw new NotImplementedException("Editing participants is not supported yet.");

    }
    
    public static Employee FromConsole()
    {
        Person inputData = Person.FromConsole();
        return new Employee(inputData.FirstName.Value, inputData.LastName.Value, inputData.Age.Value);
    }

    public override string ToString()
    {
        return $"Mitarbeiter {base.ToString()}";
    }
}