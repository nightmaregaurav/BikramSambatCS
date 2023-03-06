using DateConverter.Utils;

namespace DateConverter.Extensions
{
    public static class YearExtensions
    {
        public static NepaliDate GetYearEnd(this NepaliDate date) => YearUtils.GetYearEnd(date.Year);
        public static List<List<List<int?>>> GetYearCalender(this NepaliDate date) => YearUtils.GetYearCalender(date.Year);
    }
}