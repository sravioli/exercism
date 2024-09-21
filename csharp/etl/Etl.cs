using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> result = [];
        foreach (KeyValuePair<int, string[]> item in old)
        {
            foreach (string letter in item.Value)
            {
                result.Add(letter.ToLower(), item.Key);
            }
        }
        return result;
    }
}
