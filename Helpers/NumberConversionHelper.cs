namespace DateConverter.Helpers;

public static class NumberConversionHelper
{
    public static string ToNepaliNumber(this int? number) => number?.ToString().ToNepaliNumber() ?? "";
    public static string ToNepaliNumber(this int number) => number.ToString().ToNepaliNumber();
    internal static string ToNepaliNumber(this string number) =>  number.Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
}