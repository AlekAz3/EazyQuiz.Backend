using EazyQuiz.Extensions;

namespace EazyQuiz.Extensioons.Tests;

public class StringExtentionTests
{
    [Theory]
    [InlineData("sdaf", false)]
    [InlineData("SWDda", true)]
    [InlineData("sdaf", false)]
    [InlineData("sdwDd", true)]
    public void IsContaintsUpperCaseLetter_Tests(string str, bool expected)
    {
        bool result = str.IsContaintsUpperCaseLetter();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("sdaf", true)]
    [InlineData("SWDda", true)]
    [InlineData("sd_2af", false)]
    [InlineData("1234dqaf", true)]
    public void IsNoBannedSymbols_Tests(string str, bool expected)
    {
        bool result = str.IsNoBannedSymbols();
        Assert.Equal(expected, result);
    }
}
