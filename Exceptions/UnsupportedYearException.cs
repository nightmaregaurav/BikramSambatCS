namespace DateConverter.Exceptions;

public class UnsupportedYearException : Exception
{
    public UnsupportedYearException(int startYear, int endYear) : base(message: $"Only years between {startYear} and {endYear} are supported at the moment.")
    {
    }
}