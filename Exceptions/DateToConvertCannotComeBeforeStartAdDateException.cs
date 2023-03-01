namespace DateConverter.Exceptions
{
    public class DateToConvertCannotComeBeforeStartAdDateException : Exception
    {
        public DateToConvertCannotComeBeforeStartAdDateException(DateOnly startDate) : base(message:$"Date to convert cannot come before {startDate}AD.")
        {
        }
    }
}