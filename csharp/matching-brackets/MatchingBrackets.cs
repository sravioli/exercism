using System;
using System.Collections.Generic;
using System.Linq;

public static class MatchingBrackets
{
    private static readonly Dictionary<char, char> Brackets = new()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
    };

    public static bool IsPaired(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return true;

        Stack<char> stack = new();
        foreach (var c in input.Where(c => Brackets.ContainsKey(c) || Brackets.ContainsValue(c)))
        {
            if (Brackets.TryGetValue(c, out var value))
            {
                stack.Push(value);
                continue;
            }

            if (!stack.TryPeek(out var bracket))
                return false;

            if (c != bracket)
                return false;

            stack.Pop();
        }

        return stack.Count == 0;
    }
}
