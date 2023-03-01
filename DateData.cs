namespace DateConverter
{
    public class DateData
    {
        public static readonly DateOnly StartAdDate = new(1943, 4, 14);
        
        public static readonly string[] MonthNamesInNepali = { "बैशाख", "जेठ", "असार", "साउन", "भदौ", "असोज", "कार्तिक", "मंसिर", "पुष", "माघ", "फागुन", "चैत्र" };
        public static readonly string[] MonthNamesInEnglish = { "Baishakh", "Jestha", "Ashad", "Shrawan", "Bhadra", "Ashoj", "Kartik", "Mangsir", "Poush", "Magh", "Falgun", "Chaitra" };
        
        public static readonly string[] DayNamesInNepali = { "आइतबार", "सोमबार", "मंगलबार", "बुधबार", "बिहिबार", "शुक्रबार", "शनिबार" };
        public static readonly string[] DayNamesInEnglish = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        
        public static readonly string[] DayNamesInNepaliShort = { "आइत", "सोम", "मंगल", "बुध", "बिहि", "शुक्र", "शनि" };
        public static readonly string[] DayNamesInEnglishShort = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        
        public static readonly string[] DayNamesInNepaliShortest = { "आ", "सो", "मं", "बु", "बि", "शु", "श" };
        public static readonly string[] DayNamesInEnglishShortest = { "S", "M", "T", "W", "T", "F", "S" };
        
        public static readonly Dictionary<int, int[]> DaysInMonthsForBsYear = new()
        {
            { 2000, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2001, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2002, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2003, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2004, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2005, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2006, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2007, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2008, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 } },
            { 2009, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2010, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2011, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2012, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 } },
            { 2013, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2014, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2015, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2016, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 } },
            { 2017, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2018, new[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2019, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2020, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2021, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2022, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 } },
            { 2023, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2024, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2025, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2026, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2027, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2028, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2029, new[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 } },
            { 2030, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2031, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2032, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2033, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2034, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2035, new[] { 30, 32, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 } },
            { 2036, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2037, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2038, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2039, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 } },
            { 2040, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2041, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2042, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2043, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 } },
            { 2044, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2045, new[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2046, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2047, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2048, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2049, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 } },
            { 2050, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2051, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2052, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2053, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 } },
            { 2054, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2055, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2056, new[] { 31, 31, 32, 31, 32, 30, 30, 29, 30, 29, 30, 30 } },
            { 2057, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2058, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2059, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2060, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2061, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2062, new[] { 30, 32, 31, 32, 31, 31, 29, 30, 29, 30, 29, 31 } },
            { 2063, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2064, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2065, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2066, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 } },
            { 2067, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2068, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2069, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2070, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 30 } },
            { 2071, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2072, new[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 30 } },
            { 2073, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 31 } },
            { 2074, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2075, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2076, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 } },
            { 2077, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 31 } },
            { 2078, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2079, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 30 } },
            { 2080, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 30 } },
            { 2081, new[] { 31, 31, 32, 32, 31, 30, 30, 30, 29, 30, 30, 30 } },
            { 2082, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 } },
            { 2083, new[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 } },
            { 2084, new[] { 31, 31, 32, 31, 31, 30, 30, 30, 29, 30, 30, 30 } },
            { 2085, new[] { 31, 32, 31, 32, 30, 31, 30, 30, 29, 30, 30, 30 } },
            { 2086, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 } },
            { 2087, new[] { 31, 31, 32, 31, 31, 31, 30, 30, 29, 30, 30, 30 } },
            { 2088, new[] { 30, 31, 32, 32, 30, 31, 30, 30, 29, 30, 30, 30 } },
            { 2089, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 30, 30 } },
            { 2090, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2091, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2092, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2093, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 } },
            { 2094, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2095, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2096, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2097, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 31 } },
            { 2098, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2099, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2100, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2101, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 31 } },
            { 2102, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2103, new[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 32 } },
            { 2104, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2105, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2106, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2107, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2108, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2109, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2110, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2111, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2112, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2113, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2114, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2115, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2116, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2117, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2118, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2119, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2120, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 } },
            { 2121, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2122, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2123, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2124, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 31 } },
            { 2125, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2126, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2127, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2128, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 31 } },
            { 2129, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2130, new[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 32 } },
            { 2131, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2132, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2133, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2134, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2135, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2136, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2137, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2138, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2139, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2140, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2141, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2142, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2143, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2144, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2145, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2146, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2147, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 } },
            { 2148, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2149, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2150, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2151, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 31 } },
            { 2152, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2153, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2154, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2155, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 31 } },
            { 2156, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2157, new[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 32 } },
            { 2158, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2159, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2160, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2161, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2162, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2163, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2164, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2165, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2166, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2167, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2168, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2169, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2170, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2171, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2172, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2173, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2174, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 } },
            { 2175, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2176, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2177, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2178, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 31 } },
            { 2179, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2180, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2181, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2182, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 31 } },
            { 2183, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2184, new[] { 31, 32, 31, 32, 31, 30, 30, 29, 30, 29, 30, 32 } },
            { 2185, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2186, new[] { 31, 31, 31, 32, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2187, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2188, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2189, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2190, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2191, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2192, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2193, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2194, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2195, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2196, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2197, new[] { 30, 32, 31, 32, 31, 30, 30, 30, 29, 30, 29, 32 } },
            { 2198, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2199, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2200, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2201, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 29, 31 } },
            { 2202, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2203, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2204, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } },
            { 2205, new[] { 31, 31, 31, 32, 31, 31, 29, 30, 30, 29, 30, 31 } },
            { 2206, new[] { 31, 31, 32, 31, 31, 31, 30, 29, 30, 29, 30, 31 } },
            { 2207, new[] { 31, 31, 32, 32, 31, 30, 30, 29, 30, 29, 30, 31 } },
            { 2208, new[] { 31, 32, 31, 32, 31, 30, 30, 30, 29, 29, 30, 32 } }
        };
        
        public static readonly int StartBsYear = DaysInMonthsForBsYear.Keys.Min();
        public static readonly int EndBsYear = DaysInMonthsForBsYear.Keys.Max();
    }
}
