namespace DateConverter
{
    public class NepaliDate
    {
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }
        public DayOfWeek DayOfWeek { get; }
        public DateOnly AdInstance { get; }

        public NepaliDate(int year, int month, int day, DateOnly? adInstance)
        {
            Year = year;
            Month = month;
            Day = day;
            AdInstance = adInstance ?? DateConverterService.ConvertAdToBs(year, month, day);
            DayOfWeek = AdInstance.DayOfWeek;
        }
        
        public string MonthName => DateData.MonthNamesInEnglish[Month - 1];
        public string NepaliMonthName => DateData.MonthNamesInNepali[Month - 1];
        
        public string DayName => DateData.DayNamesInEnglish[(int) DayOfWeek];
        public string NepaliDayName => DateData.DayNamesInNepali[(int) DayOfWeek];
        
        public string DayNameShort => DateData.DayNamesInEnglishShort[(int) DayOfWeek];
        public string NepaliDayNameShort => DateData.DayNamesInNepaliShort[(int) DayOfWeek];
        
        public string DayNameNarrow => DateData.DayNamesInEnglishShortest[(int) DayOfWeek];
        public string NepaliDayNameNarrow => DateData.DayNamesInNepaliShortest[(int) DayOfWeek];

        public override string ToString() => $"{Year}-{Month}-{Day} {DayName}";
        public string ToNepaliString() => $"{Year.ToNepaliNumber()}-{Month.ToNepaliNumber()}-{Day.ToNepaliNumber()} {NepaliDayName}";
        
        public string ToDateString() => $"{Year}-{Month}-{Day}";
        public string ToNepaliDateString() => $"{Year.ToNepaliNumber()}-{Month.ToNepaliNumber()}-{Day.ToNepaliNumber()}";
    }
}