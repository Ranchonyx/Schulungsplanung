namespace Schulungsplanung.Properties;

public class BaseProperty<T> where T : notnull
{
    public T Value { get; set; }
    public string Name { get; set; }

    public BaseProperty()
    {
        
    }
    public BaseProperty(string pName, T pValue)
    {
        Value = pValue;
        Name = pName;
    }

    public override string ToString()
    {
        return $"{Name}: {Value}";
    }
}