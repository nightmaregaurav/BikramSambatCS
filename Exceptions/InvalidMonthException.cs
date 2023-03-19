namespace DateConverter.Exceptions;

public class InvalidMonthException : Exception
{
    public InvalidMonthException() : base(message: "Month cannot be less than 1 or greater than 12.")
    {
    }
}