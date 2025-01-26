using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        var steps = 0;
        var n = number;
        while (n > 1)
        {
            n = n % 2 == 0 ? n / 2 : (3 * n) + 1;
            steps++;
        }
        return steps;
    }
}
