namespace DateConverter.Exceptions
{
    public class DateToConvertCannotComeBeforeStartBsDateException : Exception
    {
        public DateToConvertCannotComeBeforeStartBsDateException(int startBsYear) : base(message: $"Date to convert cannot come before beginning of {startBsYear}BS.")
        {
        }
    }
}