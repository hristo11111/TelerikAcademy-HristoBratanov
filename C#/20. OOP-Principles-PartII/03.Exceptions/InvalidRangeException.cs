using System;

class InvalidRangeException<T>: ApplicationException
{
    public T Argument { get; private set; }
    public T Start { get; private set; }
    public T End { get; private set; }

    public InvalidRangeException(T argument, T start, T end, string message) : base(message)
    {
        this.Argument = argument;
        this.Start = start;
        this.End = end;
    }

    public override string Message
    {
        get
        {
            return string.Format("{0} is not in the right range ({1} - {2})", Argument, Start, End);
        }
    }
}
