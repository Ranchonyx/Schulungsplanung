namespace Schulungsplanung;

public class BaseProperty<T> where T : notnull
{
    public T Value { get; set; }
    public string Name { get; }

    public BaseProperty(string pName, T pValue)
    {
        this.Value = pValue;
        this.Name = pName;
    }

    public override string ToString()
    {
        return $"[{this.GetType().Name}] ({Name}:{Value})";
    }
}