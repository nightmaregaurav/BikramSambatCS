using DateConverter.Extensions;

namespace DateConverter.Helpers
{
    public abstract class CalenderPrintingHelper
    {
        private const string AdBsDaySeparator = ":";

        public static string GetBsWeekCalender(int year, int month, int referenceDay)
        {
            var date = new NepaliDate(year, month, referenceDay);
            var calender = date.GetWeekCalender();
            var result = $"{year} {date.MonthName} {calender.Min()}~{calender.Max()} Week\n";
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
            var result = $"{year} {date.MonthName} Month\n";
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
            var result = $"{year} Year\n";
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
            var result = $"{year.ToNepaliNumber()} {date.NepaliMonthName} महिना\n";
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
            var result = $"{year.ToNepaliNumber()} बर्ष\n";
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
        
        public static string GetBsWeekCalenderWithAd(int year, int month, int referenceDay)
        {
            var date = new NepaliDate(year, month, referenceDay);
            var calender = date.GetWeekCalender();
            var startDate = new NepaliDate(year, month, calender.Min() ?? referenceDay);
            var endDate = startDate.GetWeekend();
            var header1 = $"BS: {year} {startDate.MonthName} {calender.Min()}-{calender.Max()} Week\n";
            var header2 = $"AD: ({startDate.ToAd().Year} {startDate.ToAd().ToString("MMMM")} {startDate.ToAd().Day}) - ({endDate.ToAd().Year} {endDate.ToAd().ToString("MMMM")} {endDate.ToAd().Day}) Week\n";
            var result = $"{header1}{header2}";
            result += "-".Multiply(Math.Max(header1.Length, header2.Length)) + "\n";
            result += DateData.DayNamesInEnglishShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
            result += "---\t".Multiply(7) + "\n";
            
            foreach (var day in calender)
            {
                if (day != null)
                {
                    result += day + AdBsDaySeparator + startDate.ToAd().Day;
                    startDate += 1;
                }
                result += "\t";
                startDate += 1;
            }

            return result.Trim();
        }
        
        public static string GetBsMonthCalenderWithAd(int year, int month)
        {
            var date = new NepaliDate(year, month);
            var calender = date.GetMonthCalender();
            var header1 = $"BS: {year} {date.MonthName} Month\n";
            var header2 = $"AD: ({date.ToAd().Year} {date.ToAd().ToString("MMMM")}) - ({date.GetMonthEnd().ToAd().Year} {date.GetMonthEnd().ToAd().ToString("MMMM")}) Month\n";
            var result = $"{header1}{header2}";
            result += "-".Multiply(Math.Max(header1.Length, header2.Length)) + "\n";
            result += DateData.DayNamesInEnglishShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
            result += "---\t".Multiply(7) + "\n";
            
            foreach (var week in calender)
            {
                foreach (var day in week)
                {
                    if (day != null)
                    {
                        result += day + AdBsDaySeparator + date.ToAd().Day;
                        date += 1;
                    }
                    result += "\t";
                }

                result += "\n";
            }

            return result.Trim();
        }
        
        public static string GetBsYearCalenderWithAd(int year)
        {
            var date = new NepaliDate(year);
            var calender = date.GetYearCalender();
            var header1 = $"BS: {year} Year\n";
            var header2 = $"AD: {date.ToAd().Year} - {date.GetYearEnd().ToAd().Year} Year\n";
            var result = $"{header1}{header2}";
            result += "-".Multiply(Math.Max(header1.Length, header2.Length)) + "\n";

            var monthCounter = 0;
            foreach (var month in calender)
            {
                var monthHeader = $"{DateData.MonthNamesInEnglish[monthCounter]} : ({date.ToAd().ToString("MMMM")} - {date.GetMonthEnd().ToAd().ToString("MMMM")})\n";
                monthCounter++;
                
                result += monthHeader;
                result += "-".Multiply(monthHeader.Length) + "\n";
                result += DateData.DayNamesInEnglishShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
                result += "---\t".Multiply(7) + "\n";
            
                foreach (var week in month)
                {
                    foreach (var day in week)
                    {
                        if (day != null)
                        {
                            result += day + AdBsDaySeparator + date.ToAd().Day;
                            date += 1;
                        }
                        result += "\t";
                    }

                    result += "\n";
                }
            }

            return result;
        }
        
        public static string GetBsWeekCalenderWithAdInNepali(int year, int month, int referenceDay)
        {
            var date = new NepaliDate(year, month, referenceDay);
            var calender = date.GetWeekCalender();
            var startDate = new NepaliDate(year, month, calender.Min() ?? referenceDay);
            var endDate = startDate.GetWeekend();
            var header1 = $"बिसं: {year} {startDate.NepaliMonthName} {calender.Min().ToNepaliNumber()}-{calender.Max().ToNepaliNumber()} सप्ताह\n";
            var header2 = $"AD: ({startDate.ToAd().Year} {startDate.ToAd().ToString("MMMM")} {startDate.ToAd().Day}) - ({endDate.ToAd().Year} {endDate.ToAd().ToString("MMMM")} {endDate.ToAd().Day}) Week\n";
            var result = $"{header1}{header2}";
            result += "-".Multiply(Math.Max(header1.Length, header2.Length)) + "\n";
            result += DateData.DayNamesInNepaliShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
            result += "---\t".Multiply(7) + "\n";
            
            foreach (var day in calender)
            {
                if (day != null)
                {
                    result += day.ToNepaliNumber() + AdBsDaySeparator + startDate.ToAd().Day;
                    startDate += 1;
                }
                result += "\t";
                startDate += 1;
            }

            return result.Trim();
        }
        
        public static string GetBsMonthCalenderWithAdInNepali(int year, int month)
        {
            var date = new NepaliDate(year, month);
            var calender = date.GetMonthCalender();
            var header1 = $"बिसं: {year.ToNepaliNumber()} {date.NepaliMonthName} महिना\n";
            var header2 = $"AD: ({date.ToAd().Year} {date.ToAd().ToString("MMMM")}) - ({date.GetMonthEnd().ToAd().Year} {date.GetMonthEnd().ToAd().ToString("MMMM")}) Month\n";
            var result = $"{header1}{header2}";
            result += "-".Multiply(Math.Max(header1.Length, header2.Length)) + "\n";
            result += DateData.DayNamesInNepaliShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
            result += "---\t".Multiply(7) + "\n";
            
            foreach (var week in calender)
            {
                foreach (var day in week)
                {
                    if (day != null)
                    {
                        result += day.ToNepaliNumber() + AdBsDaySeparator + date.ToAd().Day;
                        date += 1;
                    }
                    result += "\t";
                }

                result += "\n";
            }

            return result.Trim();
        }
        
        public static string GetBsYearCalenderWithAdInNepali(int year)
        {
            var date = new NepaliDate(year);
            var calender = date.GetYearCalender();
            var header1 = $"बिसं: {year.ToNepaliNumber()} बर्ष\n";
            var header2 = $"AD: {date.ToAd().Year} - {date.GetYearEnd().ToAd().Year} Year\n";
            var result = $"{header1}{header2}";
            result += "-".Multiply(Math.Max(header1.Length, header2.Length)) + "\n";

            var monthCounter = 0;
            foreach (var month in calender)
            {
                var monthHeader = $"{DateData.MonthNamesInNepali[monthCounter]} : ({date.ToAd().ToString("MMMM")} - {date.GetMonthEnd().ToAd().ToString("MMMM")})\n";
                monthCounter++;
                
                result += monthHeader;
                result += "-".Multiply(monthHeader.Length) + "\n";
                result += DateData.DayNamesInNepaliShortest.Aggregate((s, s1) => s + "\t" + s1).Trim() + "\n";
                result += "---\t".Multiply(7) + "\n";
            
                foreach (var week in month)
                {
                    foreach (var day in week)
                    {
                        if (day != null)
                        {
                            result += day.ToNepaliNumber() + AdBsDaySeparator + date.ToAd().Day;
                            date += 1;
                        }
                        result += "\t";
                    }

                    result += "\n";
                }
            }

            return result;
        }
    }
}