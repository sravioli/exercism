using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(number);

        var steps = 0;
        while (number > 1)
        {
            number = number % 2 == 0 ? number / 2 : (3 * number) + 1;
            steps++;
        }
        return steps;
    }
}
