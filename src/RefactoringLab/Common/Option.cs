﻿namespace Kanadeiar.Common;

public interface INone
{
    public string Message { get; }
}

public interface ISome<out T>
{
    public T Value { get; }
}

public class Some<T>(T value) : ISome<T>
{
    T ISome<T>.Value => value;
}

public class None<T>(string message) : Some<T>(default!), INone
{
    string INone.Message => message;
}

public static class Option
{
    public static Some<T> Some<T>(T value) => new(value);

    public static Some<T> None<T>(string message) => 
        new None<T>(message);

    public static T TryGetValue<T>(this Some<T> option, Func<INone, T> noneFunc)
    {
        return option switch
        {
            INone none => noneFunc(none),
            ISome<T> some => some.Value,
            _ => throw new ArgumentOutOfRangeException(nameof(option))
        };
    }
}