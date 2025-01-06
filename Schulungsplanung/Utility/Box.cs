namespace Schulungsplanung;

public class Box<T>
{
    public T Value;

    public Box(T pValue)
    {
        Value = pValue;
    }
    
    public T Unbox()
    {
        return Value;
    }
}