using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    private static readonly int LINE_PADDING = (61 / 2) - 1;
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

    public static string DisplaySingleLine(string studentA, string studentB) =>
        string.Format("{0," + LINE_PADDING + "} ♡ {1," + -LINE_PADDING + "}", studentA, studentB);

    public static string DisplayBanner(string studentA, string studentB) =>
        string.Format(BANNER_FMT, studentA.Trim(), studentB.Trim());

    public static string DisplayGermanExchangeStudents(
        string studentA,
        string studentB,
        DateTime start,
        float hours
    ) =>
        string.Format(
            new CultureInfo("de-DE"),
            "{0} and {1} have been dating since {2:d} - that's {3:N2} hours",
            studentA,
            studentB,
            start,
            hours
        );
}
