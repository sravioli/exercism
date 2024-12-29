using System;
using System.Linq;

public static class ResistorColor
{
    private static readonly string[] ColorNames =
    [
        "black",
        "brown",
        "red",
        "orange",
        "yellow",
        "green",
        "blue",
        "violet",
        "grey",
        "white",
    ];

    public static int ColorCode(string color) => Array.IndexOf(ColorNames, color);

    public static string[] Colors() => ColorNames;
}
