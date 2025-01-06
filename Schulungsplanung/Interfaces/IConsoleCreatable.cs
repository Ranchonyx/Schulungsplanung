namespace Schulungsplanung.Interfaces;

public interface IConsoleCreatable<T>
{
    static abstract T FromConsole();
}