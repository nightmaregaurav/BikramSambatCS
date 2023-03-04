namespace DateConverter.Helpers
{
    public static class StringUtilityHelper
    {
        public static string Multiply(this string value, int iteration)
        {
            var result = "";
            for (var i = iteration - 1; i >= 0; i--)
            {
                result += value;
            }

            return result;
        }
    }
}