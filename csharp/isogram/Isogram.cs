using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var letters = word.Where(char.IsLetterOrDigit).Select(char.ToLower).ToArray();
        return letters.Distinct().Count() == letters.Length;
    }
}
