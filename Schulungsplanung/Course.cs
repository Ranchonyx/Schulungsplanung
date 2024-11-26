namespace Schulungsplanung;

public class Course : IListPrintable, IDescriptionPrintable, IHasProperties
{
    private int __MAX_PARTICIPANT__ = 15;

    private readonly BaseProperty<List<Participant>> _participants = new("Kursteilnehmer", []);

    private readonly BaseProperty<string> _courseName = new("Kursname", "");
    private readonly BaseProperty<string> _courseDescription = new("Kursbeschreibung", "");

    public Course(string pCourseName, string pCourseDescription, List<Participant>? pParticipants)
    {
        _courseName.Value = pCourseName;
        _courseDescription.Value = pCourseDescription;

        if (pParticipants != null)
        {
            if (pParticipants.Count > __MAX_PARTICIPANT__)
                throw new ParticipantLimitExceededException();
            _participants.Value = pParticipants;
        }
    }

    public void PrintDescription()
    {
        Console.WriteLine($"{_courseName}, {_courseDescription}, {_participants.Value.Count} Teilnehmer");
    }

    public void PrintList()
    {
        for (int i = 0; i < this._participants.Value.Count; i++)
        {
            Participant participant = _participants.Value.ElementAt(i);
            Console.Write($"{i}:\t");
            participant.PrintDescription();
        }
    }

    public List<object> GetProperties()
    {
        return [_courseName, _courseDescription, _participants];
    }
}