using System.Collections.Generic;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        char[] appeared = new char[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            var c = char.ToLower(word[i]);

            if (!char.IsAsciiLetter(c))
                continue;

            if (appeared.Contains(c))
                return false;

            appeared[i] = c;
        }

        return true;
    }
}
