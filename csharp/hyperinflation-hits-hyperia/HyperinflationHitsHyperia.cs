using System;
using System.Globalization;

public static class CentralBank
{
    private const string ValueTooBig = "*** Too Big ***";
    private const string ValueMuchTooBig = "*** Much Too Big ***";

    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            return checked((@base * multiplier).ToString());
        }
        catch (OverflowException)
        {
            return ValueTooBig;
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var mult = @base * multiplier;
        return float.IsInfinity(mult) ? ValueTooBig : mult.ToString(CultureInfo.InvariantCulture);
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            return (salaryBase * multiplier).ToString(CultureInfo.InvariantCulture);
        }
        catch (OverflowException)
        {
            return ValueMuchTooBig;
        }
    }
}
