namespace Schulungsplanung;

public class Teacher : Person
{
    private BaseProperty<List<Course>> _toldCourses = new("Gelehrte Kurse", []);

    public Teacher(string pFirstName, string pLastName, int pAge, List<Course>? pCourses) : base(pFirstName, pLastName, pAge)
    {
        if (pCourses != null)
        {
            this._toldCourses.Value = pCourses;
        }
    }

    public List<object> GetEditableProperties()
    {
        return [this.FirstName, this.LastName, this.Age, this._toldCourses];
    }
}