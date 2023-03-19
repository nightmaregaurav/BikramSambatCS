namespace DateConverter.Exceptions;

public class DateToConvertCannotComeAfterEndBsDateException : Exception
{
    public DateToConvertCannotComeAfterEndBsDateException(int endBsDate) : base(message:$"Date to convert cannot come after {endBsDate}BS.")
    {
    }
}