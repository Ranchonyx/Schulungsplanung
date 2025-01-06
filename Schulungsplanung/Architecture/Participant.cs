namespace Schulungsplanung;

using Interfaces;
using Properties;

public class Participant : Person, IListPrintable, IDescriptionPrintable, IEditable, IConsoleCreatable<Participant>
{
    private int _maxCourse = 15;
    public ListProperty<Course> AttendingCourses { get; set; }

    public Participant() : base()
    {
        AttendingCourses = new("Eingeschriebene Kurse", []);
    }

    public Participant(string pFirstName, string pLastName, int pAge, List<Course>? pCourses) : base(pFirstName,
        pLastName, pAge)
    {
        if (pCourses != null)
        {
            if (pCourses.Count > _maxCourse)
                throw new CourseLimitExceededException();

            AttendingCourses = new("Eingeschriebene Kurse", pCourses);
        }
    }

    public void PrintDescription()
    {
        Console.WriteLine($"(Teilnehmer) {LastName}, {FirstName}, {Age}");
    }

    public void PrintList()
    {
        var unwrappedCourses = AttendingCourses.Value.Cast<Course>().ToList();

        for (int i = 0; i < unwrappedCourses.Count; i++)
        {
            Course course = unwrappedCourses.ElementAt(i);
            Console.Write($"{i}:\t");
            course.PrintDescription();
        }
    }

    public void Edit()
    {
        //Meta bearbeiten
        var data = FromConsole();

        FirstName = data.FirstName;
        LastName = data.LastName;
        Age = data.Age;
    }

    public static Participant FromConsole()
    {
        Person inputData = Person.FromConsole();
        return new Participant(inputData.FirstName.Value, inputData.LastName.Value, inputData.Age.Value, []);
    }

    public override string ToString()
    {
        string coursesFmt = "";
        foreach (var course in AttendingCourses.Value)
        {
            coursesFmt += "\t\t" + course + "\n";
        }

        return $"Teilnehmer [ {base.ToString()} ]" + "\n" + coursesFmt;
    }
}