using System;
using System.Collections.Generic;

public static class Languages
{
    private static readonly string EXCITING_LANGUAGE = "C#";
    private static readonly int MAX_EXCITING_CAPACITY = 3;

    public static List<string> NewList() => new List<string>();

    public static List<string> GetExistingLanguages() => ["C#", "Clojure", "Elm"];

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) =>
        languages.Contains(language);

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages) =>
        !(languages.Count == 0)
        && (
            languages[0] == EXCITING_LANGUAGE
            || (languages.Count <= MAX_EXCITING_CAPACITY && languages[1] == EXCITING_LANGUAGE)
        );

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.RemoveAll(lang => lang == language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        bool isUnique = true;
        for (int i = 0; i < languages.Count && isUnique; i++)
        {
            isUnique = languages.FindAll(lang => lang == languages[i]).Count == 1;
        }
        return isUnique;
    }
}
