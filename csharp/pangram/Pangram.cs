using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Pangram
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input)
    {
        var sb = new StringBuilder();
        input
            .Where(char.IsLetter)
            .Select(char.ToLower)
            .Distinct()
            .OrderBy(c => c)
            .ToList()
            .ForEach(c => sb.Append(c));

        return string.Equals(sb.ToString(), Alphabet, StringComparison.InvariantCulture);
    }
}
