using DateConverter.Exceptions;
using DateConverter.Services;

namespace DateConverter.Utils
{
    public abstract class YearUtils
    {
        public static NepaliDate GetYearEnd(int year) => new NepaliDate(year, 12, DateData.DaysInMonthsForBsYear[year][11]);
        
        public static NepaliDate GetYearQuarterEndBs(int year, int month)
        {
            if (month is < 1 or > 12) throw new InvalidMonthException();
            
            return month switch
            {
                <= 3 => MonthUtils.GetMonthEndBs(year, 3),
                <= 6 => MonthUtils.GetMonthEndBs(year, 6),
                <= 9 => MonthUtils.GetMonthEndBs(year, 9),
                _ => MonthUtils.GetMonthEndBs(year, 12)
            };
        }
        
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