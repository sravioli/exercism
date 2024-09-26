using System;
using System.Text;

public static class Identifier
{
    private const char DASH_CH = '-';
    private const char GREEK_LOWERCASE_ALPHA = 'α';
    private const char GREEK_LOWERCASE_OMEGA = 'ω';

    private const char UNDERSCORE_CH = '_';
    private static readonly char[] CTRL_STR = ['C', 'T', 'R', 'L'];

    public static string Clean(string identifier)
    {
        StringBuilder stringBuilder = new StringBuilder();
        bool shouldUppercaseNextChar = false;
        foreach (char ch in identifier)
        {
            switch (ch)
            {
                case char when char.IsBetween(ch, GREEK_LOWERCASE_ALPHA, GREEK_LOWERCASE_OMEGA):
                    break;
                case char when shouldUppercaseNextChar:
                    stringBuilder.Append(char.ToUpperInvariant(ch));
                    break;
                case char when char.IsWhiteSpace(ch):
                    stringBuilder.Append(UNDERSCORE_CH);
                    break;
                case char when char.IsControl(ch):
                    stringBuilder.Append(CTRL_STR);
                    break;
                case char when char.IsLetter(ch):
                    stringBuilder.Append(ch);
                    break;
                default:
                    break;
            }
            shouldUppercaseNextChar = ch == DASH_CH;
        }
        return stringBuilder.ToString();
    }
}
