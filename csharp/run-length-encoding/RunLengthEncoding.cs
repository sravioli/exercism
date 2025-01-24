using System.Text;
using System.Text.RegularExpressions;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        var sb = new StringBuilder();
        var last = input[0];
        var count = 0;
        foreach (var c in input)
        {
            if (last == c)
            {
                count++;
                continue;
            }

            sb.Append(count > 1 ? count : "");
            sb.Append(last);
            count = 1;
            last = c;
        }
        sb.Append(count > 1 ? count : "");
        sb.Append(last);

        return sb.ToString();
    }

    public static string Decode(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return input;

        var sb = new StringBuilder();
        foreach (Match match in Regex.Matches(input, @"(\d*)(\D)"))
        {
            var num = int.Parse(
                match.Groups[1].Value == string.Empty ? "1" : match.Groups[1].Value
            );
            var letter = char.Parse(match.Groups[2].Value);
            sb.Append(letter, num);
        }

        return sb.ToString();
    }
}
