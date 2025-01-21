using System;
using System.Linq;

public static class Pangram
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input) =>
        input.ToLower().Where(char.IsLetter).GroupBy(c => c).Count() == 26;
}
