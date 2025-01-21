using System.Linq;

public static class Pangram
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input) =>
        "abcdefghijklmnopqrstuvwxyz".All(letter => input.ToLower().Contains(letter));
}
