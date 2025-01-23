using System;
using System.Linq;

public class Anagram
{
    private static string _word;

    public Anagram(string baseWord) => _word = baseWord.ToLower();

    public string[] FindAnagrams(string[] potentialMatches)
    {
        string w;
        return potentialMatches
            .Where(word =>
            {
                w = word.ToLower();
                return w.All(c =>
                        _word.Contains(c) && w.Count(ch => ch == c) == _word.Count(ch => ch == c)
                    )
                    && w.Length == _word.Length
                    && !w.Equals(_word, StringComparison.InvariantCultureIgnoreCase);
            })
            .ToArray();
    }
}
