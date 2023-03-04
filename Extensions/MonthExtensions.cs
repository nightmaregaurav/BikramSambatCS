using DateConverter.Services;
using DateConverter.Utils;

namespace DateConverter.Extensions
{
    public static class MonthExtensions
    {
        public static NepaliDate GetMonthEnd(this NepaliDate date) => MonthUtils.GetMonthEndBs(date.Year, date.Month);
        public static List<List<int?>> GetMonthCalender(this NepaliDate date) => MonthUtils.GetMonthCalender(date.Year, date.Month);
    }
}