namespace DateConverter.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException(string value) : base(message: $"Provided value {value} is not in valid date Format. (yyyy-mm-dd or yyyy/mm/dd or yyyy mm dd)")
        {
        }
    }
}