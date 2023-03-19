using DateConverter.Utils;

namespace DateConverter.Extensions;

public static class WeekExtensions
{
    public static NepaliDate GetWeekend(this NepaliDate date) => WeekUtils.GetWeekendBs(date.Year, date.Month, date.Day);
    public static NepaliDate GetFirstDayOfWeek(this NepaliDate date) => WeekUtils.GetFirstDayOfWeekBs(date.Year, date.Month, date.Day);
    public static List<int?> GetWeekCalender(this NepaliDate date) => WeekUtils.GetWeekCalenderBs(date.Year, date.Month, date.Day);
}