using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        if (string.IsNullOrEmpty(statement) || string.IsNullOrWhiteSpace(statement))
            return "Fine. Be that way!";

        var s = statement.Trim();
        var isAskingQuestion = s[^1] == '?';
        var isShouting =
            s.Any(c => !(char.IsPunctuation(c) || char.IsDigit(c)) && char.IsAsciiLetter(c))
            && s.Where(char.IsAsciiLetter).All(char.IsAsciiLetterUpper);

        return isShouting switch
        {
            true when isAskingQuestion => "Calm down, I know what I'm doing!",
            true => "Whoa, chill out!",
            false when isAskingQuestion => "Sure.",
            _ => "Whatever.",
        };
    }
}
