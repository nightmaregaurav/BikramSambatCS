using System.Text.Json.Serialization;
using DateConverter.Converters;
using DateConverter.Exceptions;
using DateConverter.Extensions;
using DateConverter.Helpers;
using DateConverter.Services;

namespace DateConverter;

[JsonConverter(typeof(NepaliDateJsonConverter))]
public class NepaliDate : IComparable, IFormattable, IEquatable<NepaliDate>
{
    public int Year { get; }
    public int Month { get; }
    public int Day { get; }

    private DayOfWeek DayOfWeek { get; }
    public DateOnly AdInstance { get; }

    public NepaliDate(int year, int month = 1, int day = 1, DateOnly? adInstance = null)
    {
        DateValidationService.ValidateBsDate(year, month, day);

        Year = year;
        Month = month;
        Day = day;

        AdInstance = adInstance ?? DateConverterService.ConvertBsToAd(year, month, day);
        DayOfWeek = AdInstance.DayOfWeek;
    }

    public string MonthName => DateData.MonthNamesInEnglish[Month - 1];
    public string NepaliMonthName => DateData.MonthNamesInNepali[Month - 1];

    public int WeekDay => (int) DayOfWeek + 1;

    public string DayName => DateData.DayNamesInEnglish[(int) DayOfWeek];
    public string NepaliDayName => DateData.DayNamesInNepali[(int) DayOfWeek];

    public string DayNameShort => DateData.DayNamesInEnglishShort[(int) DayOfWeek];
    public string NepaliDayNameShort => DateData.DayNamesInNepaliShort[(int) DayOfWeek];

    public string DayNameNarrow => DateData.DayNamesInEnglishShortest[(int) DayOfWeek];
    public string NepaliDayNameNarrow => DateData.DayNamesInNepaliShortest[(int) DayOfWeek];

    [Obsolete("The provider argument is not used. Use ToString(String) instead.")]
    public string ToString(string? format, IFormatProvider? provider) => this.ToString(format ?? "");

    public override string ToString() => ToString('/');
    public string ToString(char separator) => $"{Year%10000:0000}{separator}{Month%100:00}{separator}{Day%100:00} {DayName}";

    public string ToNepaliString() => ToNepaliString('/');
    public string ToNepaliString(char separator) => $"{(Year%10000).ToString("0000").ToNepaliNumber()}{separator}{(Month%100).ToString("00").ToNepaliNumber()}{separator}{(Day%100).ToString("00").ToNepaliNumber()} {NepaliDayName}";

    public string ToDateString() => ToDateString('/');
    public string ToDateString(char separator) => $"{Year%10000:0000}{separator}{Month%100:00}{separator}{Day%100:00}";

    public string ToNepaliDateString() => ToNepaliDateString('/');
    public string ToNepaliDateString(char separator) => $"{(Year%10000).ToString("0000").ToNepaliNumber()}{separator}{(Month%100).ToString("00").ToNepaliNumber()}{separator}{(Day%100).ToString("00").ToNepaliNumber()}";

    /// <summary>Converts given string to NepaliDate.<br/>Supports formats:<br/> 2077-01-01<br/> 2077/01/01<br/> 2077 01 01</summary>
    /// <param name="date">Date string to convert</param>
    /// <exception cref="InvalidDateFormatException">Thrown when date string is not in supported format</exception>
    /// <returns>NepaliDate instance</returns>
    public static NepaliDate FromString(string date)
    {
        var split = date.Split('-', '/', ' ');
        if (split.Take(3).All(x => int.TryParse(x, out _))) return new NepaliDate(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        throw new InvalidDateFormatException(date);
    }

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
