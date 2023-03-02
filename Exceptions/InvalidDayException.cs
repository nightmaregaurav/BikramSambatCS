namespace DateConverter.Exceptions
{
    public class InvalidDayException : Exception
    {
        public InvalidDayException(int maxDays) : base(message: "This month has only " + maxDays + " days.")
        {
        }
    }
}