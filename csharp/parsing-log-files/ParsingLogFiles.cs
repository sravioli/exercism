using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class LogParser
{
    private static readonly string LINE_VALIDATION_PAT = @"^\[(TRC|DBG|INF|WRN|ERR|FLT)\].*?$";
    private static readonly string LINE_SPLIT_PAT = @"\<[\^\*\=\-]+\>";
    private static readonly string PASSWD_QUOTED_COUNT_PAT = "\".*password.*\"";
    private static readonly string EOL_REMOVE_PAT = @"end-of-line(\d+)";
    private static readonly string PASSWD_OFFENDING_PAT = @"(password[^\s]+)";
    private static readonly string PASSWD_GOOD_PREFIX = "--------";

    public bool IsValidLine(string text) =>
        Regex.IsMatch(text, LINE_VALIDATION_PAT, RegexOptions.Singleline);

    public string[] SplitLogLine(string text) =>
        Regex.Split(text, LINE_SPLIT_PAT, RegexOptions.Singleline);

    public int CountQuotedPasswords(string lines) =>
        Regex.Count(lines, PASSWD_QUOTED_COUNT_PAT, RegexOptions.IgnoreCase);

    public string RemoveEndOfLineText(string line) =>
        Regex.Replace(line, EOL_REMOVE_PAT, string.Empty, RegexOptions.Singleline);

    public string[] ListLinesWithPasswords(string[] lines)
    {
        string[] linesWithPasswords = new string[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            Match match = Regex.Match(line, PASSWD_OFFENDING_PAT, RegexOptions.IgnoreCase);
            Group passwd = match.Groups[0];
            linesWithPasswords[i] = $"{(passwd.Length == 0 ? PASSWD_GOOD_PREFIX : passwd)}: {line}";
        }
        return linesWithPasswords;
    }
}
