using DateConverter.Helpers;

namespace DateConverter.Extensions;

public static class DateFormattingExtensions
{
    ///  <summary>Formats the value of the current instance using the specified format.</summary>
    ///  <param name="date">The NepaliDate instance to format.</param>
    ///  <param name="format">The format to use.<br/>
    ///  <br/>
    ///  yyyyn: 4 character number representation of year in nepali<br/>
    ///  yyyn: 3 character number representation of year in nepali<br/>
    ///  yyn: 2 character number representation of year in nepali<br/>
    ///  yn: number representation of year as it is in nepali<br/>
    ///  yyyy: 4 character number representation of year in english<br/>
    ///  yyy: 3 character number representation of year in english<br/>
    ///  yy: 2 character number representation of year in english<br/>
    ///  y: number representation of year as it is in english<br/>
    ///  <br/>
    ///  mmn: 2 character number representation of month in nepali<br/>
    ///  mn: number representation of month as it is in nepali<br/>
    ///  mm: 2 character number representation of month in english<br/>
    ///  m: number representation of month as it is in english<br/>
    ///  <br/>
    ///  ddn: 2 character number representation of day in nepali<br/>
    ///  dn: number representation of day as it is in nepali<br/>
    ///  ddn: 2 character number representation of day in english<br/>
    ///  d: number representation of day as it is in english<br/>
    /// <br/>
    ///  wn: number representation of week day as it is in nepali<br/>
    ///  w: number representation of week day as it is in english<br/>
    ///  <br/>
    ///  MMn: month name in nepali<br/>
    ///  MM: month name in english<br/>
    ///  <br/>
    ///  DDDn: full weekday name in nepali<br/>
    ///  DDn: short weekday name in nepali<br/>
    ///  Dn: even short weekday name in nepali<br/>
    ///  DDD: full weekday name in english<br/>
    ///  DD: short weekday name in english<br/>
    ///  D: even short weekday name in english<br/>
    ///  <br/>
    ///  Fn: full date string in nepali<br/>
    ///  fn: date string in nepali<br/>
    ///  F: full date string in english<br/>
    ///  f: date string in english<br/>
    ///  </param>
    ///  <returns>The value of the current instance in the specified format.</returns>
    public static string ToString(this NepaliDate date, string format) => format
        .Replace("yyyyn", $"{(date.Year % 10000).ToString("0000").ToNepaliNumber()}")
        .Replace("yyyn", $"{(date.Year % 1000).ToString("000").ToNepaliNumber()}")
        .Replace("yyn", $"{(date.Year % 100).ToString("00").ToNepaliNumber()}")
        .Replace("yn", $"{date.Year.ToNepaliNumber()}")
        .Replace("yyyy", $"{date.Year % 10000:0000}")
        .Replace("yyy", $"{date.Year % 1000:000}")
        .Replace("yy", $"{date.Year % 100:00}")
        .Replace("y", $"{date.Year}")
            
        .Replace("mmn", $"{(date.Month % 100).ToString("00").ToNepaliNumber()}")
        .Replace("mn", $"{date.Month.ToNepaliNumber()}")
        .Replace("mm", $"{date.Month % 100:00}")
        .Replace("m", $"{date.Month}")
            
        .Replace("ddn", $"{(date.Day % 100).ToString("00").ToNepaliNumber()}")
        .Replace("dn", $"{date.Day.ToNepaliNumber()}")
        .Replace("dd", $"{date.Day % 100:00}")
        .Replace("d", $"{date.Day}")
            
        .Replace("wn", $"{date.WeekDay.ToNepaliNumber()}")
        .Replace("w", $"{date.WeekDay}")
            
        .Replace("MMn", $"{date.NepaliMonthName}")
        .Replace("MM", $"{date.MonthName}")
            
        .Replace("DDDn", $"{date.NepaliDayName}")
        .Replace("DDn", $"{date.NepaliDayNameShort}")
        .Replace("Dn", $"{date.NepaliDayNameNarrow}")
        .Replace("DDD", $"{date.DayName}")
        .Replace("DD", $"{date.DayNameShort}")
        .Replace("D", $"{date.DayNameNarrow}")
            
        .Replace("Fn", $"{date.ToNepaliString()}")
        .Replace("fn", $"{date.ToNepaliDateString()}")
        .Replace("F", $"{date.ToString()}")
        .Replace("f", $"{date.ToDateString()}");
}