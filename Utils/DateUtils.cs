using DateConverter.Services;

namespace DateConverter.Utils;

public class DateUtils
{
    public static NepaliDate TodayBs() => DateConverterService.ConvertAdToBs(DateOnly.FromDateTime(DateTime.Today));
}