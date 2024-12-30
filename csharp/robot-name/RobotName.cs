using System;
using System.Collections.Generic;

public class Robot
{
    private static readonly Random Rand = new(DateTime.Now.Millisecond);
    private static readonly HashSet<string> RobotTracker = [];

    public string Name { get; private set; } = GetUniqueName();

    public void Reset() => Name = GetUniqueName();

    private static string CreateName()
    {
        var name = new char[5];
        for (var i = 0; i < 2; i++)
        {
            name[i] = (char)Rand.Next('A', 'Z' + 1);
        }
        for (var i = 2; i < 5; i++)
        {
            name[i] = (char)Rand.Next('0', '9' + 1);
        }
        return new string(name);
    }

    private static string GetUniqueName()
    {
        var robotName = CreateName();
        while (!RobotTracker.Add(robotName))
        {
            robotName = CreateName();
        }
        return robotName;
    }
}
