using System;
using System.Collections.Generic;
using System.Linq;

public static class ScrabbleScore
{
    private static readonly int NO_SCORE = 0;
    private static readonly Dictionary<int, string[]> _scoreReference =
        new()
        {
            { 1, ["A", "E", "I", "O", "U", "L", "N", "R", "S", "T"] },
            { 2, ["D", "G"] },
            { 3, ["B", "C", "M", "P"] },
            { 4, ["F", "H", "V", "W", "Y"] },
            { 5, ["K"] },
            { 8, ["J", "X"] },
            { 10, ["Q", "Z"] },
        };

    public static int Score(string input)
    {
        int score = NO_SCORE;
        foreach (char c in input)
        {
            foreach (KeyValuePair<int, string[]> item in _scoreReference)
            {
                if (item.Value.Contains(c.ToString().ToUpper()))
                {
                    score += item.Key;
                    break;
                }
            }
        }
        return score;
    }
}
