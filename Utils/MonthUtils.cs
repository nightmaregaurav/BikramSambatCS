namespace DateConverter.Utils;

public abstract class MonthUtils
{
    public static NepaliDate GetMonthEndBs(int year, int month) => new(year, month, DateData.DaysInMonthsForBsYear[year][month - 1]);
    public static List<List<int?>> GetMonthCalender(int year, int month)
    {
        var bsDate = new NepaliDate(year, month);
        var monthEnd = DateData.DaysInMonthsForBsYear[year][month - 1];

        var startWeekDay = bsDate.WeekDay;

        var day = 1;
        var monthArray = new List<List<int?>>();
        for (var j = 1;; j++)
        {
            var week = new List<int?>();
            for (var i = 1; i < 8; i++)
            {
                if (startWeekDay > i && j == 1) week.Add(null);
                else week.Add(day++);
                if (day > monthEnd) break;
            }
            monthArray.Add(week);
            if (day > monthEnd) break;
        }

        return monthArray;

    }
}