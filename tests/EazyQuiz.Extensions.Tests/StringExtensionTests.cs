namespace EazyQuiz.Extensions.Tests;

public class StringExtensionTests
{
    [Theory]
    [InlineData("sdaf", false)]
    [InlineData("SWDda", true)]
    [InlineData("sdwDd", true)]
    public void IsContainsUpperCaseLetterTests(string str, bool expected)
    {
        bool result = str.IsContaintsUpperCaseLetter();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("sdaf", true)]
    [InlineData("SWDda", true)]
    [InlineData("sd_2af", false)]
    [InlineData("1234dqaf", true)]
    public void IsNoBannedSymbolsTests(string str, bool expected)
    {
        bool result = str.IsNoBannedSymbols();
        Assert.Equal(expected, result);
    }
}
