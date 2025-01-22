using System;
using System.Linq;
using System.Text;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var sb = new StringBuilder();
        var words = phrase.Replace("-", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            sb.Append(char.ToUpper(word.First(char.IsAsciiLetter)));
        }
        return sb.ToString();
    }
}
