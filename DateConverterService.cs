using DateConverter.Exceptions;

namespace DateConverter
{
    public static class DateConverterService
    {
        public static NepaliDate ToBs(this DateOnly date)
        {
            if (date.CompareTo(DateData.StartAdDate) < 0) throw new DateToConvertCannotComeBeforeStartAdDateException(DateData.StartAdDate);
            var daysDiff = date.DayNumber - DateData.StartAdDate.DayNumber;
            var bsDate = GetBsDateFromDaysDiff(daysDiff);
            return new NepaliDate(bsDate.Item1, bsDate.Item2, bsDate.Item3, date);
        }

        public static NepaliDate TodayBs() => DateOnly.FromDateTime(DateTime.Today).ToBs();
        
        public static NepaliDate GetMonthEndBs(this NepaliDate date) => GetMonthEndBs(date.Year, date.Month);
        public static NepaliDate GetMonthEndBs(int year, int month) => new(year, month, DateData.DaysInMonthsForBsYear[year][month - 1]);

        public static NepaliDate AddDays(this NepaliDate date, int days) => date + days;
        
        /// <summary>Adds days of each nepali months including current month to the supplied NepaliDate.</summary>
        /// <param name="date">The date to add days to.</param>
        /// <param name="months">The number of months to add days from.</param>
        /// <returns>The NepaliDate with added days.</returns>
        public static NepaliDate AddMonthDays(this NepaliDate date, int months) {
            var daysOffset = DateData.DaysInMonthsForBsYear.Where(x => x.Key >= date.Year).SelectMany(x => x.Value).ToList().Take(months).Sum();
            return date + daysOffset;
        }

        /// <summary>Adds days of each nepali Year including current year to the supplied NepaliDate.</summary>
        /// <param name="date">The date to add days to.</param>
        /// <param name="years">The number of years to add days from.</param>
        /// <returns>The NepaliDate with added days.</returns>
        public static NepaliDate AddYearDays(this NepaliDate date, int years)
        {
            var daysOffset = DateData.DaysInMonthsForBsYear.Where(x => x.Key >= date.Year && x.Key < date.Year + years).SelectMany(x => x.Value).Sum();
            return date + daysOffset;
        }

        /// <summary>Adds months to the supplied NepaliDate disregarding number of days in nepali month.</summary>
        /// <param name="date">The date to add days to.</param>
        /// <param name="months">The number of months to add.</param>
        /// <param name="preserveExcessDays">If true, excess days will be added to next month. If false, excess days will be discarded and month end will be used.</param>
        /// <returns>The NepaliDate with added days.</returns>
        public static NepaliDate AddMonth(this NepaliDate date, int months, bool preserveExcessDays = true)
        {
            var year = date.Year;
            var month = date.Month;
            var day = date.Day;
            
            month += months;
            while (month > 12)
            {
                year++;
                month -= 12;
            }
            
            var maxDayInGivenMonthOfGivenYear = DateData.DaysInMonthsForBsYear[year][month - 1];
            if (day > maxDayInGivenMonthOfGivenYear)
            {
                if (preserveExcessDays)
                {
                    day -= maxDayInGivenMonthOfGivenYear;
                    month++;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }   
                } else
                {
                    day = maxDayInGivenMonthOfGivenYear;
                }
            }
            
            return new NepaliDate(year, month, day);
        }

        /// <summary>Adds years to the supplied NepaliDate disregarding number of days in nepali year.</summary>
        /// <param name="date">The date to add days to.</param>
        /// <param name="years">The number of years to add.</param>
        /// <param name="preserveExcessDays">If true, excess days will be added to next month. If false, excess days will be discarded and month end will be used.</param>
        /// <returns>The NepaliDate with added days.</returns>
        public static NepaliDate AddYear(this NepaliDate date, int years, bool preserveExcessDays = true)
        {
            var year = date.Year;
            var month = date.Month;
            var day = date.Day;
            
            year += years;
            
            var maxDayInGivenMonthOfGivenYear = DateData.DaysInMonthsForBsYear[year][month - 1];
            if (day > maxDayInGivenMonthOfGivenYear)
            {
                if (preserveExcessDays)
                {
                    day -= maxDayInGivenMonthOfGivenYear;
                    month++;
                    if (month > 12)
                    {
                        year++;
                        month -= 12;
                    }   
                } else
                {
                    day = maxDayInGivenMonthOfGivenYear;
                }
            }
            
            return new NepaliDate(year, month, day);
        } 

        public static string ToNepaliNumber(this int number) => number.ToString().ToNepaliNumber();
        internal static string ToNepaliNumber(this string number) =>  number.Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");

        internal static void ValidateBsDate(int year, int month, int day)
        {
            if (year < DateData.StartBsYear || year > DateData.EndBsYear) throw new UnsupportedYearException(DateData.StartBsYear, DateData.EndBsYear);
            if (month is < 1 or > 12) throw new InvalidMonthException();
            var maxDayInGivenMonthOfGivenYear = DateData.DaysInMonthsForBsYear[year][month - 1];
            if (day < 1 || day > maxDayInGivenMonthOfGivenYear) throw new InvalidDayException(maxDayInGivenMonthOfGivenYear);
        }
        
        internal static DateOnly ConvertBsToAd(int year, int month, int day)
        {
            ValidateBsDate(year, month, day);
            var daysDiff = 0;
            foreach (var yearData in DateData.DaysInMonthsForBsYear.Where(x => x.Key <= year))
            {
                if (yearData.Key == year)
                {
                    for (var i = 1; i < month; i++)
                    {
                        daysDiff += yearData.Value[i - 1];
                    }
                    daysDiff += day - 1;
                    break;
                }
                daysDiff += yearData.Value.Sum();
            }
            
            if (daysDiff < 0) throw new DateToConvertCannotComeBeforeStartBsDateException(DateData.StartBsYear);
            
            return DateData.StartAdDate.AddDays(daysDiff);
        }

        private static Tuple<int, int, int> GetBsDateFromDaysDiff(int daysDiff)
        {
            var found = false;
            
            var bsYear = 0;
            var bsMonth = 0;
            var bsDay = 0;

            foreach (var yearData in DateData.DaysInMonthsForBsYear.OrderBy(x => x.Key))
            {
                bsYear = yearData.Key;
                bsMonth = 0;
                foreach (var days in yearData.Value)
                {
                    bsMonth++;
                    bsDay = 0;
                    if (daysDiff <= days)
                    {
                        found = true;
                        bsDay = daysDiff + 1;
                        break;
                    }

                    daysDiff -= days;
                }
                if (found) break;
            }
            
            if (!found) throw new DateToConvertCannotComeAfterEndBsDateException(DateData.EndBsYear);

            return new Tuple<int, int, int>(bsYear, bsMonth, bsDay);
        }
    }
}