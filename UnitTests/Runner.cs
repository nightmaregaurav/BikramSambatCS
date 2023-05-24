using DateConverter.Helpers;

namespace DateConverter.UnitTests;

public class Runner
{
    public static void Run()
    {
        var calender = CalenderPrintingHelper.GetBsYearCalender(2080);
        Console.WriteLine(calender);
    }
}
