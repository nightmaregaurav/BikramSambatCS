using DateConverter.Utils;

namespace DateConverter.Extensions
{
    public static class YearExtensions
    {
        public static List<List<List<int?>>> GetYearCalender(this NepaliDate date) => YearUtils.GetYearCalender(date.Year);
    }
}