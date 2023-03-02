namespace DateConverter
{
    public class NepaliDate : IComparable, IFormattable, IEquatable<NepaliDate>
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

        /// <summary>Formats the value of the current instance using the specified format.</summary>
        /// <param name="format">The format to use.<br/>
        /// <br/>
        /// yyyyn: 4 character number representation of year in nepali<br/>
        /// yyyn: 3 character number representation of year in nepali<br/>
        /// yyn: 2 character number representation of year in nepali<br/>
        /// yn: number representation of year as it is in nepali<br/>
        /// yyyy: 4 character number representation of year in english<br/>
        /// yyy: 3 character number representation of year in english<br/>
        /// yy: 2 character number representation of year in english<br/>
        /// y: number representation of year as it is in english<br/>
        /// <br/>
        /// mmn: 2 character number representation of month in nepali<br/>
        /// mn: number representation of month as it is in nepali<br/>
        /// mm: 2 character number representation of month in english<br/>
        /// m: number representation of month as it is in english<br/>
        /// <br/>
        /// ddn: 2 character number representation of day in nepali<br/>
        /// dn: number representation of day as it is in nepali<br/>
        /// ddn: 2 character number representation of day in english<br/>
        /// d: number representation of day as it is in english<br/>
        ///<br/>
        /// wn: number representation of week day as it is in nepali<br/>
        /// w: number representation of week day as it is in english<br/>
        /// <br/>
        /// MMn: month name in nepali<br/>
        /// MM: month name in english<br/>
        /// <br/>
        /// DDDn: full weekday name in nepali<br/>
        /// DDn: short weekday name in nepali<br/>
        /// Dn: even short weekday name in nepali<br/>
        /// DDD: full weekday name in english<br/>
        /// DD: short weekday name in english<br/>
        /// D: even short weekday name in english<br/>
        /// <br/>
        /// Fn: full date string in nepali<br/>
        /// fn: date string in nepali<br/>
        /// F: full date string in english<br/>
        /// f: date string in english<br/>
        /// </param>
        /// <returns>The value of the current instance in the specified format.</returns>
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
        
        /// <summary>Formats the value of the current instance using the specified format.<br/> Only Kept for compatibility.<br/><b> Use ToString(format) instead!</b></summary>
        public string ToString(string? format, IFormatProvider? _) => ToString(format ?? "");
        
        public override string ToString() => ToString('/');
        public string ToString(char separator) => $"{Year%10000:0000}{separator}{Month%100:00}{separator}{Day%100:00} {DayName}";
        
        public string ToNepaliString() => ToNepaliString('/');
        public string ToNepaliString(char separator) => $"{(Year%10000).ToString("0000").ToNepaliNumber()}{separator}{(Month%100).ToString("00").ToNepaliNumber()}{separator}{(Day%100).ToString("00").ToNepaliNumber()} {NepaliDayName}";

        public string ToDateString() => ToDateString('/');
        public string ToDateString(char separator) => $"{Year%10000:0000}{separator}{Month%100:00}{separator}{Day%100:00}";
        
        public string ToNepaliDateString() => ToNepaliDateString('/');
        public string ToNepaliDateString(char separator) => $"{(Year%10000).ToString("0000").ToNepaliNumber()}{separator}{(Month%100).ToString("00").ToNepaliNumber()}{separator}{(Day%100).ToString("00").ToNepaliNumber()}";

        public int CompareTo(NepaliDate obj) => AdInstance.DayNumber - obj.AdInstance.DayNumber;
        public int CompareTo(object? obj) => obj?.GetType() != typeof(NepaliDate) ? 0 : CompareTo((NepaliDate) obj);
        
        public static bool operator ==(NepaliDate left, NepaliDate right) => left.Year == right.Year && left.Month == right.Month && left.Day == right.Day;
        public static bool operator !=(NepaliDate left, NepaliDate right) => !(left == right);
        public static int operator -(NepaliDate left, NepaliDate right) => left.CompareTo(right);
        public static NepaliDate operator -(NepaliDate left, int right) => left.AdInstance.AddDays(-right).ToBs();
        public static NepaliDate operator +(NepaliDate left, int right) => left.AdInstance.AddDays(right).ToBs();
        public static bool operator <(NepaliDate left, NepaliDate right) => left.CompareTo(right) < 0;
        public static bool operator >(NepaliDate left, NepaliDate right) => left.CompareTo(right) > 0;
        public static bool operator >=(NepaliDate left, NepaliDate right) => left.CompareTo(right) >= 0;
        public static bool operator <=(NepaliDate left, NepaliDate right) => left.CompareTo(right) <= 0;
        
        public bool Equals(NepaliDate? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this == other;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((NepaliDate) obj);
        }
        public override int GetHashCode() => HashCode.Combine(Year, Month, Day);
    }
}