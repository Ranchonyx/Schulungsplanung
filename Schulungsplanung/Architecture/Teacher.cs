using Schulungsplanung.Interfaces;

namespace Schulungsplanung;

using Properties;

public class Teacher : Person, IEditable, IConsoleCreatable<Teacher>
{
    public ListProperty<Course> ToldCourses { get; set; }

    public Teacher() : base()
    {
        ToldCourses = new("Lehrende Kurse", []);
    }

    public Teacher(string pFirstName, string pLastName, int pAge, List<Course>? pCourses) : base(pFirstName, pLastName,
        pAge)
    {
        if (pCourses != null)
        {
            ToldCourses = new("Lehrende Kurse", pCourses);
        }
    }

    public void Edit()
    {
        var editMetaOrCoursesChoice =
            Util.Choice("Details", "Kurse", "Abbrechen", "Möchten Sie Details oder Kurse bearbeiten?");
        switch (editMetaOrCoursesChoice)
        {
            case 0:
                //New teacher somehow...
                var data = FromConsole();

                FirstName = data.FirstName;
                LastName = data.LastName;
                Age = data.Age;
                break;
            case 1:
                ToldCourses.EditContents(DataRegistry.GlobalCourses.Unbox().Value);
                break;
            case 2:
                return;
            default:
                Console.WriteLine("Ungültige Eingabe!");
                return;
        }
    }

    public static Teacher FromConsole()
    {
        Person inputData = Person.FromConsole();
        return new Teacher(inputData.FirstName.Value, inputData.LastName.Value, inputData.Age.Value, []);
    }

    public override string ToString()
    {
        string coursesFmt = "";
        foreach (var course in ToldCourses.Value)
        {
            coursesFmt += "\t\t" + course + "\n";
        }

        return $"Dozent [ {base.ToString()} ]" + "\n" + coursesFmt;
    }
}