using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var hypotenuse = Math.Sqrt(x * x + y * y);

        return hypotenuse switch
        {
            <= 10 and > 5 => 1,
            <= 5 and > 1 => 5,
            <= 1 => 10,
            _ => 0,
        };
    }
}
