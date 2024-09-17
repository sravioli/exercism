using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string s, string delimiter) =>
        s.Substring(s.IndexOf(delimiter) + delimiter.Length);
    
    public static string SubstringBetween(this string s, string start, string end) =>
        s.Substring(0, s.IndexOf(end)).Substring(s.IndexOf(start) + start.Length);
    
    public static string Message(this string str) => str.SubstringAfter(": ");
    
    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}