using System;
using System.Collections.Generic;

public static class ScrabbleScore
{
    private static readonly int NO_SCORE = 0;
    private static readonly Dictionary<int, List<string>> _scoreReference =
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
            foreach (KeyValuePair<int, List<string>> item in _scoreReference)
            {
                score += item.Value.Contains(c.ToString().ToUpper()) ? item.Key : NO_SCORE;
            }
        }
        return score;
    }
}
