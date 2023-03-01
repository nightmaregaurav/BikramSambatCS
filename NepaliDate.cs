namespace DateConverter
{
    public class NepaliDate
    {
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }
        private DayOfWeek DayOfWeek { get; }
        public DateOnly AdInstance { get; }

        public NepaliDate(int year, int month, int day, DateOnly? adInstance)
        {
            Year = year;
            Month = month;
            Day = day;
            AdInstance = adInstance ?? DateConverterService.ConvertBsToAd(year, month, day);
            DayOfWeek = AdInstance.DayOfWeek;
        }
        
        public string MonthName => DateData.MonthNamesInEnglish[Month - 1];
        public string NepaliMonthName => DateData.MonthNamesInNepali[Month - 1];

        public int WeekDay => (int) DayOfWeek;
        
        public string DayName => DateData.DayNamesInEnglish[(int) DayOfWeek];
        public string NepaliDayName => DateData.DayNamesInNepali[(int) DayOfWeek];
        
        public string DayNameShort => DateData.DayNamesInEnglishShort[(int) DayOfWeek];
        public string NepaliDayNameShort => DateData.DayNamesInNepaliShort[(int) DayOfWeek];
        
        public string DayNameNarrow => DateData.DayNamesInEnglishShortest[(int) DayOfWeek];
        public string NepaliDayNameNarrow => DateData.DayNamesInNepaliShortest[(int) DayOfWeek];

        // yyyyn: 4 character number representation of year in nepali
        // yyyn: 3 character number representation of year in nepali
        // yyn: 2 character number representation of year in nepali
        // yn: number representation of year as it is in nepali
        // yyyy: 4 character number representation of year in english
        // yyy: 3 character number representation of year in english
        // yy: 2 character number representation of year in english
        // y: number representation of year as it is in english
        
        // mmn: 2 character number representation of month in nepali
        // mn: number representation of month as it is in nepali
        // mm: 2 character number representation of month in english
        // m: number representation of month as it is in english
        
        // ddn: 2 character number representation of day in nepali
        // dn: number representation of day as it is in nepali
        // ddn: 2 character number representation of day in english
        // d: number representation of day as it is in english
        
        // wn: number representation of week day as it is in nepali
        // w: number representation of week day as it is in english
        
        // MMn: month name in nepali
        // MM: month name in english
        
        // DDDn: full weekday name in nepali
        // DDn: short weekday name in nepali
        // Dn: even short weekday name in nepali
        // DDD: full weekday name in english
        // DD: short weekday name in english
        // D: even short weekday name in english

        // Fn: full date string in nepali
        // fn: date string in nepali
        // F: full date string in english
        // f: date string in english

        public string ToString(string format) => format
            .Replace("yyyyn", $"{(Year % 10000).ToString("0000").ToNepaliNumber()}")
            .Replace("yyyn", $"{(Year % 1000).ToString("000").ToNepaliNumber()}")
            .Replace("yyn", $"{(Year % 100).ToString("00").ToNepaliNumber()}")
            .Replace("yn", $"{Year.ToNepaliNumber()}")
            .Replace("yyyy", $"{Year % 10000:0000}")
            .Replace("yyy", $"{Year % 1000:000}")
            .Replace("yy", $"{Year % 100:00}")
            .Replace("y", $"{Year}")
            
            .Replace("mmn", $"{(Month % 100).ToString("00").ToNepaliNumber()}")
            .Replace("mn", $"{Month.ToNepaliNumber()}")
            .Replace("mm", $"{Month % 100:00}")
            .Replace("m", $"{Month}")
            
            .Replace("ddn", $"{(Day % 100).ToString("00").ToNepaliNumber()}")
            .Replace("dn", $"{Day.ToNepaliNumber()}")
            .Replace("dd", $"{Day % 100:00}")
            .Replace("d", $"{Day}")
            
            .Replace("wn", $"{WeekDay.ToNepaliNumber()}")
            .Replace("w", $"{WeekDay}")
            
            .Replace("MMn", $"{NepaliMonthName}")
            .Replace("MM", $"{MonthName}")
            
            .Replace("DDDn", $"{NepaliDayName}")
            .Replace("DDn", $"{NepaliDayNameShort}")
            .Replace("Dn", $"{NepaliDayNameNarrow}")
            .Replace("DDD", $"{DayName}")
            .Replace("DD", $"{DayNameShort}")
            .Replace("D", $"{DayNameNarrow}")
            
            .Replace("Fn", $"{ToNepaliString()}")
            .Replace("fn", $"{ToNepaliDateString()}")
            .Replace("F", $"{ToString()}")
            .Replace("f", $"{ToDateString()}");

        public override string ToString() => ToString('/');
        public string ToString(char separator) => $"{Year%10000:0000}{separator}{Month%100:00}{separator}{Day%100:00} {DayName}";
        public string ToNepaliString() => ToNepaliString('/');
        public string ToNepaliString(char separator) => $"{(Year%10000).ToString("0000").ToNepaliNumber()}{separator}{(Month%100).ToString("00").ToNepaliNumber()}{separator}{(Day%100).ToString("00").ToNepaliNumber()} {NepaliDayName}";

        public string ToDateString() => ToDateString('/');
        public string ToDateString(char separator) => $"{Year%10000:0000}{separator}{Month%100:00}{separator}{Day%100:00}";
        
        public string ToNepaliDateString() => ToNepaliDateString('/');
        public string ToNepaliDateString(char separator) => $"{(Year%10000).ToString("0000").ToNepaliNumber()}{separator}{(Month%100).ToString("00").ToNepaliNumber()}{separator}{(Day%100).ToString("00").ToNepaliNumber()}";
    }
}