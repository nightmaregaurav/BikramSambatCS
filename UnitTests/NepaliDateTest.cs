using Xunit;

namespace DateConverter.UnitTests;

public class NepaliDateTest
{
    [Fact]
    public void Test__NepaliDate__ToString__Returns__ProperlyFormattedNepaliDate()
    {
        var date = new NepaliDate(2077);
        Assert.Equal("2077/01/01 Monday", date.ToString());
    }
}
