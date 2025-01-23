using System;
using System.Numerics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) =>
        Math.Pow(realNumber, (double)r.Numerator / r.Denominator);
}

public struct RationalNumber(int numerator, int denominator)
{
    public int Numerator { get; private set; } = numerator;

    public int Denominator { get; private set; } = denominator;

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            (r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator),
            (r1.Denominator * r2.Denominator)
        ).Reduce();

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(
            (r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator),
            (r1.Denominator * r2.Denominator)
        ).Reduce();

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) =>
        new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator).Reduce();

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        if (r2.Numerator == 0)
            throw new DivideByZeroException("Cannot divide by zero.");

        return new RationalNumber(
            (r1.Numerator * r2.Denominator),
            (r2.Numerator * r1.Denominator)
        ).Reduce();
    }

    public RationalNumber Abs()
    {
        Numerator = Math.Abs(Numerator);
        Denominator = Math.Abs(Denominator);
        return Reduce();
    }

    public RationalNumber Reduce()
    {
        var gcd = (int)BigInteger.GreatestCommonDivisor(Numerator, Denominator);
        gcd = Denominator < 0 ? -gcd : gcd;
        Numerator /= gcd;
        Denominator /= gcd;
        return this;
    }

    public RationalNumber Exprational(int power)
    {
        if (power < 0)
        {
            return new RationalNumber(
                (int)Math.Pow(Denominator, -power),
                (int)Math.Pow(Numerator, -power)
            ).Reduce();
        }

        Numerator = (int)Math.Pow(Numerator, power);
        Denominator = (int)Math.Pow(Denominator, power);
        return Reduce();
    }
}
