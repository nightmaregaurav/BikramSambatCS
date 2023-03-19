using DateConverter.Exceptions;

namespace DateConverter.Services;

public abstract class DateValidationService
{
    public static void ValidateBsDate(int year, int month, int day)
    {
        if (year < DateData.StartBsYear || year > DateData.EndBsYear) throw new UnsupportedYearException(DateData.StartBsYear, DateData.EndBsYear);
        if (month is < 1 or > 12) throw new InvalidMonthException();
        var maxDayInGivenMonthOfGivenYear = DateData.DaysInMonthsForBsYear[year][month - 1];
        if (day < 1 || day > maxDayInGivenMonthOfGivenYear) throw new InvalidDayException(maxDayInGivenMonthOfGivenYear);
    }
}
