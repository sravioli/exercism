using System;
using System.Linq;
using static System.StringComparison;

public static class Bob
{
    public static string Response(string statement)
    {
        if (string.IsNullOrWhiteSpace(statement))
            return "Fine. Be that way!";

        var isAskingQuestion = statement.Trim().EndsWith('?');
        var isShouting =
            statement.Any(char.IsLetter) && statement.Equals(statement.ToUpperInvariant());

        return isShouting switch
        {
            true when isAskingQuestion => "Calm down, I know what I'm doing!",
            true => "Whoa, chill out!",
            false when isAskingQuestion => "Sure.",
            _ => "Whatever.",
        };
    }
}
