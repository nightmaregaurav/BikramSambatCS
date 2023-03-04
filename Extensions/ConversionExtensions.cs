using DateConverter.Services;

namespace DateConverter.Extensions
{
    public static class ConversionExtensions
    {
        public static NepaliDate ToBs(this DateOnly date) => DateConverterService.ConvertAdToBs(date);
        public static DateOnly ToAd(this NepaliDate date) => date.AdInstance;
    }
}