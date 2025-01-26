using System;

public static class Triangle
{
    private static bool IsValid(double a, double b, double c) =>
        !(a.Equals(0) || b.Equals(0) || c.Equals(0)) && (a + b >= c && b + c >= a && a + c >= b);

    public static bool IsScalene(double side1, double side2, double side3) =>
        IsValid(side1, side2, side3)
        && (!side1.Equals(side2) && !side2.Equals(side3) && !side3.Equals(side1));

    public static bool IsIsosceles(double side1, double side2, double side3) =>
        IsValid(side1, side2, side3)
        && (side1.Equals(side2) || side2.Equals(side3) || side3.Equals(side1));

    public static bool IsEquilateral(double side1, double side2, double side3) =>
        IsValid(side1, side2, side3)
        && (side1.Equals(side2) && side2.Equals(side3) && side3.Equals(side1));
}
