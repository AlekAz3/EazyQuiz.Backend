
namespace EazyQuiz.Extensions;
[System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:Удалить непрочитанные закрытые члены", Justification = "<Временно>")]
public static class StringExtension
{
    private static readonly List<char> AlphabetUpperCase = new()
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
        'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
        'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    private static readonly List<char> AlphabetLowerCase = new()
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i',
        'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
        's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
    };

    private static readonly List<char> Numeric = new()
    {
        '0','1', '2', '3', '4', '5', '6', '7', '8', '9'
    };

    public static bool IsEqual(string a, string b)
    {
        return a == b;
    }

    public static bool IsMoreEightSymbols(this string str)
    {
        return str.Length >= 8;
    }

    public static bool IsNoBannedSymbols(this string str)
    {
        var chars = str.ToCharArray().ToList();

        return true;
    }
}
