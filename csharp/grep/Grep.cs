using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var shouldPrependFilename = files.Length > 1;
        var shouldPrependLineNumber = flags.Contains("-n");
        var shouldInvertProgram = flags.Contains("-v");
        var shouldReturnOnlyFilenames = flags.Contains("-l");

        var regexOptions = flags.Contains("-i") ? RegexOptions.IgnoreCase : RegexOptions.None;
        var regexPattern = flags.Contains("-x") ? $"^{pattern}" : pattern;

        var matches = new List<string>();
        foreach (var file in files)
        {
            var fileLines = File.ReadAllLines(file);
            for (var i = 0; i < fileLines.Length; i++)
            {
                var line = fileLines[i];

                if (Regex.IsMatch(line, regexPattern, regexOptions) == shouldInvertProgram)
                    continue;

                if (shouldReturnOnlyFilenames)
                {
                    matches.Add(file);
                    continue;
                }

                var fileName = shouldPrependFilename ? $"{file}:" : string.Empty;
                var lineNumber = shouldPrependLineNumber ? $"{i + 1}:" : string.Empty;
                matches.Add($"{fileName}{lineNumber}{line}");
            }
        }

        return string.Join('\n', matches.Distinct());
    }
}
