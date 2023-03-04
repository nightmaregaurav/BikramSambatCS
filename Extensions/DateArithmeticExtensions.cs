namespace DateConverter.Extensions
{
    public static class DateArithmeticExtensions
    {
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
            if (day <= maxDayInGivenMonthOfGivenYear) return new NepaliDate(year, month, day);
            if (preserveExcessDays)
            {
                day -= maxDayInGivenMonthOfGivenYear;
                month++;
                if (month <= 12) return new NepaliDate(year, month, day);
                year++;
                month -= 12;
            } else
            {
                day = maxDayInGivenMonthOfGivenYear;
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
            if (day <= maxDayInGivenMonthOfGivenYear) return new NepaliDate(year, month, day);
            if (preserveExcessDays)
            {
                day -= maxDayInGivenMonthOfGivenYear;
                month++;
                if (month <= 12) return new NepaliDate(year, month, day);
                year++;
                month -= 12;
            } else
            {
                day = maxDayInGivenMonthOfGivenYear;
            }

            return new NepaliDate(year, month, day);
        }
    }
}