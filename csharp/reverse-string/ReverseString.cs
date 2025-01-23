using System;
using System.Linq;

public static class ReverseString
{
    public static string Reverse(string input) =>
        input.ToCharArray().Reverse().Aggregate(string.Empty, (current, c) => current + c);
}
