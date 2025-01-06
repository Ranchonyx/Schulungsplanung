namespace Schulungsplanung;

using Interfaces;
using Properties;

public class Course : IListPrintable, IDescriptionPrintable, IEditable, IConsoleCreatable<Course>
{
    private int __MAX_PARTICIPANT__ = 15;

    public ListProperty<Participant> _participants { get; set; }
    public StringProperty _courseName { get; set; }
    public StringProperty _courseDescription { get; set; }

    public Course()
    {
    }

    public Course(string pCourseName, string pCourseDescription, List<Participant>? pParticipants)
    {
        _courseName = StringProperty.From("Kursname", pCourseName);
        _courseDescription = StringProperty.From("Kursbeschreibung", pCourseDescription);

        if (pParticipants != null)
        {
            if (pParticipants.Count > __MAX_PARTICIPANT__)
                throw new ParticipantLimitExceededException();
            _participants = new("Kursteilnehmer", pParticipants);
        }
    }

    public void PrintDescription()
    {
        Console.WriteLine($"{_courseName}, {_courseDescription}, {_participants.Value.Count} Teilnehmer");
    }

    public void PrintList()
    {
        var unwrappedParticipants = _participants.Value;
        for (int i = 0; i < unwrappedParticipants.Count; i++)
        {
            Participant participant = unwrappedParticipants.ElementAt(i);
            Console.Write($"{i}:\t");
            participant.PrintDescription();
        }
    }

    public void Edit()
    {
        int choice = Util.Choice("Details", "Teilnehmer", "Abbrechen", "Details oder Teilnehmer bearbeiten?");

        switch (choice)
        {
            case 0:
                //Meta bearbeiten
                var data = FromConsole();

                _courseName = data._courseName;
                _courseDescription = data._courseDescription;
                break;
            case 1:
                //Teilnehmer Bearbeiten
                _participants.EditContents(DataRegistry.GlobalParticipants.Unbox().Value);
                break;
            case 2:
            default:
                return;
        }
    }

    public static Course FromConsole()
    {
        Console.WriteLine("Kursnamen eingeben:");
        string courseName = Console.ReadLine()!;
        Console.WriteLine("Kursbeschreibung eingeben:");
        string courseDescription = Console.ReadLine()!;

        return new Course(courseName, courseDescription, []);
    }

    public override string ToString()
    {
        return $"Kurs: [{_courseName}, {_courseDescription}]";
    }
}