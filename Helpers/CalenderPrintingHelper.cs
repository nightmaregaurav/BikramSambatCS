using DateConverter.Extensions;

namespace DateConverter.Helpers
{
    public abstract class CalenderPrintingHelper
    {
        public static string GetBsWeekCalender(int year, int month, int referenceDay)
        {
            var date = new NepaliDate(year, month, referenceDay);
            var calender = date.GetWeekCalender();
            var result = $"{year} {date.MonthName} {calender.First()}~{calender.Last()} Week\n";
            result += "-".Multiply(result.Length) + "\n";
            result += DateData.DayNamesInEnglishShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
            result += "---\t".Multiply(7) + "\n";
            
            foreach (var day in calender)
            {
                result += day;
                result += "\t";
            }

            return result.Trim();
        }
        
        public static string GetBsMonthCalender(int year, int month)
        {
            var date = new NepaliDate(year, month);
            var calender = date.GetMonthCalender();
            var result = $"{year} {date.MonthName}\n";
            result += "-".Multiply(result.Length) + "\n";
            result += DateData.DayNamesInEnglishShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
            result += "---\t".Multiply(7) + "\n";
            
            foreach (var week in calender)
            {
                foreach (var day in week)
                {
                    result += day;
                    result += "\t";
                }

                result += "\n";
            }

            return result.Trim();
        }
        
        public static string GetBsYearCalender(int year)
        {
            var date = new NepaliDate(year);
            var calender = date.GetYearCalender();
            var result = $"{year}\n";
            result += "-".Multiply(result.Length) + "\n";

            var monthCounter = 0;
            foreach (var month in calender)
            {
                var monthHeader = $"{DateData.MonthNamesInEnglish[monthCounter]}\n";
                monthCounter++;
                
                result += monthHeader;
                result += "-".Multiply(monthHeader.Length) + "\n";
                result += DateData.DayNamesInEnglishShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
                result += "---\t".Multiply(7) + "\n";
            
                foreach (var week in month)
                {
                    foreach (var day in week)
                    {
                        result += day;
                        result += "\t";
                    }

                    result += "\n";
                }
            }

            return result;
        }
        
        public static string GetBsWeekCalenderInNepali(int year, int month, int referenceDay)
        {
            var date = new NepaliDate(year, month, referenceDay);
            var calender = date.GetWeekCalender();
            var result = $"{year.ToNepaliNumber()} {date.NepaliMonthName} {calender.Min()?.ToNepaliNumber()}~{calender.Max()?.ToNepaliNumber()} सप्ताह\n";
            result += "-".Multiply(result.Length) + "\n";
            result += DateData.DayNamesInNepaliShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
            result += "---\t".Multiply(7) + "\n";
            
            foreach (var day in calender)
            {
                result += day?.ToNepaliNumber();
                result += "\t";
            }

            return result.Trim();
        }
        
        public static string GetBsMonthCalenderInNepali(int year, int month)
        {
            var date = new NepaliDate(year, month);
            var calender = date.GetMonthCalender();
            var result = $"{year.ToNepaliNumber()} {date.NepaliMonthName}\n";
            result += "-".Multiply(result.Length) + "\n";
            result += DateData.DayNamesInNepaliShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
            result += "---\t".Multiply(7) + "\n";
            
            foreach (var week in calender)
            {
                foreach (var day in week)
                {
                    result += day?.ToNepaliNumber();
                    result += "\t";
                }

                result += "\n";
            }

            return result.Trim();
        }
        
        public static string GetBsYearCalenderInNepali(int year)
        {
            var date = new NepaliDate(year);
            var calender = date.GetYearCalender();
            var result = $"{year.ToNepaliNumber()}\n";
            result += "-".Multiply(result.Length) + "\n";

            var monthCounter = 0;
            foreach (var month in calender)
            {
                var monthHeader = $"{DateData.MonthNamesInNepali[monthCounter]}\n";
                monthCounter++;
                
                result += monthHeader;
                result += "-".Multiply(monthHeader.Length) + "\n";
                result += DateData.DayNamesInNepaliShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
                result += "---\t".Multiply(7) + "\n";
            
                foreach (var week in month)
                {
                    foreach (var day in week)
                    {
                        result += day?.ToNepaliNumber();
                        result += "\t";
                    }

                    result += "\n";
                }
            }

            return result;
        }
    }
}