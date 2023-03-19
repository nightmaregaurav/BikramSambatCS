namespace DateConverter.Utils;

public abstract class WeekUtils
{
    public static NepaliDate GetWeekendBs(int year, int month, int referenceDay)
    {
        var bsDate = new NepaliDate(year, month, referenceDay);
        var dayOffset = 7 - bsDate.WeekDay;
        return bsDate + dayOffset;
    }

    public static NepaliDate GetFirstDayOfWeekBs(int year, int month, int referenceDay)
    {
        var bsDate = new NepaliDate(year, month, referenceDay);
        var dayOffset = bsDate.WeekDay - 1;
        return bsDate - dayOffset;
    }

    public static List<int?> GetWeekCalenderBs(int year, int month, int referenceDay)
    {
        var bsDate = new NepaliDate(year, month, referenceDay);
        var sundayOffset = bsDate.WeekDay - 1;
        var saturdayOffset = 7 - bsDate.WeekDay;
        var maxNumberOfDaysInMonth = DateData.DaysInMonthsForBsYear[year][month - 1];

        var startDay = 1;
        var weekDayStart = 1;
        if (referenceDay - sundayOffset > 1) startDay = referenceDay - sundayOffset;
        else weekDayStart = bsDate.WeekDay - (referenceDay - 1);

        var weekDayEnd = 7;
        if (referenceDay + saturdayOffset > maxNumberOfDaysInMonth) weekDayEnd = bsDate.WeekDay + (maxNumberOfDaysInMonth - referenceDay);

        var week = new List<int?>();
        for (var i = 1; i < 8; i++)
            if (i < weekDayStart || i > weekDayEnd) week.Add(null);
            else week.Add(startDay++);

        return week;
    }
}