using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> counts = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 },
        };
        foreach (char ch in sequence)
        {
            if (!counts.TryGetValue(ch, out var value))
            {
                throw new ArgumentException($"'{ch}' is not a valid Nucleotide");
            }
            counts[ch] = ++value;
        }
        return counts;
    }
}
