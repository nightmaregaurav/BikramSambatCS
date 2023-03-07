using DateConverter.Services;

namespace DateConverter.Utils
{
    public abstract class YearUtils
    {
        public static NepaliDate GetYearEnd(int year) => new NepaliDate(year, 12, DateData.DaysInMonthsForBsYear[year][11]);
        public static int GetDaysInYear(int year)
        {
            DateValidationService.ValidateBsDate(year,1, 1);
            return DateData.DaysInMonthsForBsYear[year].Sum();
        }

        public static List<List<List<int?>>> GetYearCalender(int year)
        {
            var yearArray = new List<List<List<int?>>>();
            for (var i = 1; i < 13; i++)
            {
                yearArray.Add(MonthUtils.GetMonthCalender(year, i));
            }

            return yearArray;
        }
    }
}