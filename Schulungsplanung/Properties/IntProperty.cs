namespace Schulungsplanung.Properties;
using Schulungsplanung.Interfaces;

public class IntProperty : BaseProperty<int>, IEditable
{
    public IntProperty()
    {
        
    }
    public IntProperty(string pName, int pValue) : base(pName, pValue)
    {
    }

    public static IntProperty From(string pName, int pValue)
    {
        return new IntProperty(pName, pValue);
    }

    public void Edit()
    {
        while (true)
        {
            var editResult = Util.SafeToInt(Console.ReadLine());

            //If hasFailed
            if (editResult.Item2)
            {
                continue;
            }

            //editResult.Item1.Value can not be null here!
            this.Value = editResult.Item1!.Value;
            return;
        }
    }
}