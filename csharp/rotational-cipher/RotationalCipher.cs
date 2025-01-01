public static class RotationalCipher
{
    private static readonly char[] Alphabet = ("abcdefghijklmnopqrstuvwxyz").ToCharArray();

    public static string Rotate(string text, int shiftKey)
    {
        var result = new char[text.Length];
        var charArray = text.ToCharArray();
        for (var i = 0; i < charArray.Length; i++)
        {
            var ch = charArray[i];
            if (!char.IsAsciiLetter(ch))
            {
                result[i] = ch;
                continue;
            }
            var isUpper = char.IsUpper(ch);
            var index = (isUpper ? char.ToLower(ch) : ch) - Alphabet[0];
            var c = Alphabet[(index + shiftKey) % 26];
            result[i] = isUpper ? char.ToUpper(c) : c;
        }
        return new string(result);
    }
}
