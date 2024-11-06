namespace Kanadeiar.Common;

public interface INone
{
    public string Error { get; }
}

public class Some<T>(T value, bool success = true)
{
    public bool Success { get; } = success;

    public T Value => value;
}

public class None<T>(string error) : Some<T>(default!, false), INone
{
    public string Error => error;
}

public static class Option
{
    public static Some<T> Some<T>(T value) => new(value);

    public static Some<T> None<T>(string message) => 
        new None<T>(message);
}