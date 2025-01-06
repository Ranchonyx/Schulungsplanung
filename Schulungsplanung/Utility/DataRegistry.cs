using Schulungsplanung.Properties;

namespace Schulungsplanung;

public static class DataRegistry
{
    public static Box<ListProperty<Participant>> GlobalParticipants { get; private set; }
    public static Box<ListProperty<Employee>> GlobalEmployees { get; private set; }
    public static Box<ListProperty<Teacher>> GlobalTeachers { get; private set; }
    public static Box<ListProperty<Course>> GlobalCourses { get; private set; }

    public static void Initialise(ListProperty<Participant> participants, ListProperty<Employee> employees,
        ListProperty<Teacher> teachers, ListProperty<Course> courses)
    {
        GlobalParticipants = new(participants);
        GlobalEmployees = new(employees);
        GlobalTeachers = new(teachers);
        GlobalCourses = new(courses);

        /*
        Console.WriteLine($"{GlobalParticipants.Unbox().Value.Count} participants globalised.");
        Console.WriteLine($"{GlobalEmployees.Unbox().Value.Count} employees globalised.");
        Console.WriteLine($"{GlobalTeachers.Unbox().Value.Count} teachers globalised.");
        Console.WriteLine($"{GlobalCourses.Unbox().Value.Count} courses globalised.");
        */

    }
}