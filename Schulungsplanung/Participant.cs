namespace Schulungsplanung;

public class Participant : Person, IListPrintable, IDescriptionPrintable, IHasProperties, IEditable
{
    private int __MAX_COURSE__ = 15;
    private readonly BaseProperty<List<Course>> _attendingCourses = new("Eingeschriebene Kurse", []);

    public Participant(string pFirstName, string pLastName, int pAge, List<Course>? pCourses) : base(pFirstName,
        pLastName, pAge)
    {
        if (pCourses != null)
        {
            if (pCourses.Count > __MAX_COURSE__)
                throw new CourseLimitExceededException();

            _attendingCourses.Value = pCourses;
        }
    }

    public void PrintDescription()
    {
        Console.WriteLine($"(Teilnehmer) {LastName}, {FirstName}, {Age}");
    }

    public void PrintList()
    {
        for (int i = 0; i < _attendingCourses.Value.Count; i++)
        {
            Course course = _attendingCourses.Value.ElementAt(i);
            Console.Write($"{i}:\t");
            course.PrintDescription();
        }
    }

    public List<object> GetProperties()
    {
        return [FirstName, LastName, Age, _attendingCourses];
    }

    public bool Edit()
    {
        var props = GetProperties();
        foreach (var rawProp in props)
        {
            switch (rawProp)
            {
                //Edit int property
                case BaseProperty<int> prop:
                    Console.WriteLine($"Bearbeite '{prop.Name}' ({prop.Value.GetType()})...");
                    int? intVal = Util.SafeToInt(Console.ReadLine()!);
                    if (intVal == null)
                    {
                        
                    }
                    prop.Value = value;
                    break;
                //Edit string property
                case BaseProperty<string> prop:
                    Console.WriteLine($"Bearbeite '{prop.Name}' ({prop.Value.GetType()})...");
                    int value = Convert.ToInt32(Console.ReadLine());
                    prop.Value = value;

                    break;
                case BaseProperty<List<IEditable>> prop:
                    foreach (var editable in prop.Value)
                    {
                        editable.Edit();
                    }

                    break;
            }
        }

        return true;
    }
}