namespace Schulungsplanung.Properties;
using Schulungsplanung.Interfaces;

public class StringProperty : BaseProperty<string>, IEditable
{
    public StringProperty() {}
    public StringProperty(string pName, string pValue) : base(pName, pValue)
    {
        
    }

    public static StringProperty From(string pName, string pValue)
    {
        return new StringProperty(pName, pValue);
    }

    public void Edit()
    {
        while (true)
        {
            var editResult = Util.SafeToString(Console.ReadLine());
            //If hasFailed
            if (editResult.Item2)
            {
                continue;
            }

            //editResult.Item1.Value can not be null here!
            this.Value = editResult.Item1!;
            return;
        }
    }
}