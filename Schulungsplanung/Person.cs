namespace Schulungsplanung;

public class Person
{
    protected BaseProperty<string> FirstName;
    protected BaseProperty<string> LastName;
    protected BaseProperty<int> Age;

    protected Person(string pFirstName, string pLastName, int pAge)
    {
        this.FirstName = new BaseProperty<string>("Vorname", pFirstName);
        this.LastName = new BaseProperty<string>("Nachname", pLastName);
        this.Age = new BaseProperty<int>("Alter", pAge);
    }
}