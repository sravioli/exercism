using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    private static readonly int MAX_LINE_WIDTH = 61;
    private static readonly string BANNER_FMT =
        @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {0}  +  {1}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";

    public static string DisplaySingleLine(string studentA, string studentB)
    {
        string names = $"{studentA} ♡ {studentB}";
        int padLeft = ((MAX_LINE_WIDTH - names.Length) / 2) + names.Length;
        return names.PadLeft(padLeft - 1).PadRight(MAX_LINE_WIDTH);
    }

    public static string DisplayBanner(string studentA, string studentB) =>
        string.Format(BANNER_FMT, studentA.Trim(), studentB.Trim());

    public static string DisplayGermanExchangeStudents(
        string studentA,
        string studentB,
        DateTime start,
        float hours
    ) =>
        $"{studentA} and {studentB} have been dating since {start:dd.MM.yyyy} - that's {hours.ToString("N2", new CultureInfo("de-DE"))} hours";
}
