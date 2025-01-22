using System;
using System.Text;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var sb = new StringBuilder();
        var words = phrase.Split([' ', '-', '_'], StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            sb.Append(char.ToUpper(word[0]));
        }
        return sb.ToString();
    }
}
