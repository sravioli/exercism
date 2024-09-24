using System;
using System.Text;

public static class Identifier
{
    private const char DASH_CH = '-';
    private const char GREEK_LOWERCASE_START_CH = 'α';
    private const char GREEK_LOWERCASE_END_CH = 'ω';

    private const char UNDERSCORE_CH = '_';
    private const string CTRL_STR = "CTRL";

    public static string Clean(string identifier)
    {
        StringBuilder stringBuilder = new StringBuilder();
        bool shouldUppercaseNextChar = false;
        foreach (char ch in identifier)
        {
            switch (ch)
            {
                case char when ch == DASH_CH:
                    shouldUppercaseNextChar = true;
                    break;
                case char when shouldUppercaseNextChar:
                    stringBuilder.Append(char.ToUpper(ch));
                    shouldUppercaseNextChar = false;
                    break;
                case char when ch >= GREEK_LOWERCASE_START_CH && ch <= GREEK_LOWERCASE_END_CH:
                    break;
                case char when char.IsControl(ch):
                    stringBuilder.Append(CTRL_STR);
                    break;
                case char when char.IsWhiteSpace(ch):
                    stringBuilder.Append(UNDERSCORE_CH);
                    break;
                case char when char.IsLetter(ch):
                    stringBuilder.Append(ch);
                    break;
                default:
                    break;
            }
        }
        return stringBuilder.ToString();
    }
}
