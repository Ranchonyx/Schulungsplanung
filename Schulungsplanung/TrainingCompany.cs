using Schulungsplanung.Interfaces;
using Schulungsplanung.Properties;

namespace Schulungsplanung;

public class TrainingCompany
{
    public ListProperty<Participant> Participants { get; set; }
    public ListProperty<Employee> Employees { get; set; }
    public ListProperty<Teacher> EmployedTeachers { get; set; }
    public ListProperty<Course> OfferedCourses { get; set; }

    public TrainingCompany()
    {
        Participants = new("Alle Teilnehmer", []);
        Employees = new("Alle Mitarbeiter", []);
        EmployedTeachers = new("Alle Dozenten", []);
        OfferedCourses = new("Alle Kurse", []);
    }

    public bool Edit()
    {
        Console.Clear();
        Console.WriteLine("1. Mitarbeiter-Menü");
        Console.WriteLine("2. Kurs-Menü");
        Console.WriteLine("3. Dozenten-Menü");
        Console.WriteLine("4. Teilnehmer-Menü");
        Console.WriteLine("5. Schließen");

        var choice = Util.SafeToInt(Console.ReadLine());

        //If input has failed...
        if (choice.Item2)
        {
            Console.WriteLine("Der eingegebene Wert liegt außerhalb des gültigen Bereichs.");
            bool quit = !Util.Ask("Weiter bearbeiten?");
            if (quit)
                return false;
            Edit();
        }

        //Choice is fine from here on out...
        switch (choice.Item1!)
        {
            case 1:
                Console.Clear();

                Employees.PrintList();
                var employeeEditChoice = Util.Choice("Neu", "Bearbeiten", "Abbrechen", "Neu anlegen oder Bearbeiten?");
                switch (employeeEditChoice)
                {
                    case 0:
                        //New employee somehow...
                        var newEmployee = Employee.FromConsole();
                        Employees.Value.Add(newEmployee);
                        Console.WriteLine("Mitarbeiter hinzugefügt.");
                        break;
                    case 1:
                        Employees.EditContents(DataRegistry.GlobalEmployees.Unbox().Value);
                        break;
                    case 2:
                        return true;
                    default:
                        Console.WriteLine("Ungültige Eingabe!");
                        return true;
                }

                break;
            case 2:
                Console.Clear();
                
                OfferedCourses.PrintList();
                var courseEditChoice = Util.Choice("Neu", "Bearbeiten", "Abbrechen", "Neu anlegen oder Bearbeiten?");
                switch (courseEditChoice)
                {
                    case 0:
                        //New course somehow...
                        var newCourse = Course.FromConsole();
                        OfferedCourses.Value.Add(newCourse);
                        Console.WriteLine("Kurs hinzugefügt.");
                        break;
                    case 1:
                        OfferedCourses.EditContents(DataRegistry.GlobalCourses.Unbox().Value);
                        break;
                    case 2:
                        return true;
                    default:
                        Console.WriteLine("Ungültige Eingabe!");
                        return true;
                }

                break;
            case 3:
                Console.Clear();
                
                EmployedTeachers.PrintList();
                var teacherEditChoice = Util.Choice("Neu", "Bearbeiten", "Abbrechen", "Neu anlegen oder Bearbeiten?");
                switch (teacherEditChoice)
                {
                    case 0:
                        //New teacher somehow...
                        var newTeacher = Teacher.FromConsole();
                        EmployedTeachers.Value.Add(newTeacher);
                        Console.WriteLine("Dozent hinzugefügt.");
                        break;
                    case 1:
                        EmployedTeachers.EditContents(DataRegistry.GlobalTeachers.Unbox().Value);
                        break;
                    case 2:
                        return true;
                    default:
                        Console.WriteLine("Ungültige Eingabe!");
                        return true;
                }

                break;
            case 4:
                Console.Clear();
                Participants.PrintList();
                var editParticipantsChoice =
                    Util.Choice("Neu", "Bearbeiten", "Abbrechen", "Neu anlegen oder Bearbeiten?");
                switch (editParticipantsChoice)
                {
                    case 0:
                        //New participant somehow...
                        var newParticipant = Participant.FromConsole();
                        Participants.Value.Add(newParticipant);
                        Console.WriteLine("Teilnehmer hinzugefügt.");
                        break;
                    case 1:
                        Participants.EditContents(DataRegistry.GlobalParticipants.Unbox().Value);
                        break;
                    case 2:
                        return true;
                    default:
                        Console.WriteLine("Ungültige Eingabe!");
                        return true;
                }

                break;
            case 5:
                bool bail = Util.Ask("Wirklich schließen? [Y/N]");
                if (bail)
                    return false;
                break;
            default:
                Console.WriteLine("Ungültige Eingabe!");
                bool quit = !Util.Ask("Weiter bearbeiten? [Y/N]");
                if (quit)
                    return false;
                Edit();
                break;
        }

        return true;
    }
}