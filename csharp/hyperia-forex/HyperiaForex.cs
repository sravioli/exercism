using System;

public struct CurrencyAmount(decimal amount, string currency)
{
    private decimal amount = amount;
    private string currency = currency;

    private static bool AreValid(CurrencyAmount x, CurrencyAmount y) =>
        x.currency != y.currency ? throw new ArgumentException("Currencies must be equal") : true;

    public static bool operator ==(CurrencyAmount x, CurrencyAmount y) =>
        AreValid(x, y) && x.currency == y.currency && x.amount == y.amount;

    public static bool operator !=(CurrencyAmount x, CurrencyAmount y) => !(x == y);

    public static bool operator >(CurrencyAmount x, CurrencyAmount y) =>
        AreValid(x, y) && x.amount > y.amount;

    public static bool operator <(CurrencyAmount x, CurrencyAmount y) =>
        AreValid(x, y) && x.amount < y.amount;

    public static CurrencyAmount operator +(CurrencyAmount x, CurrencyAmount y)
    {
        if (!AreValid(x, y))
            return default;
        x.amount += y.amount;
        return x;
    }

    public static CurrencyAmount operator -(CurrencyAmount x, CurrencyAmount y)
    {
        if (!AreValid(x, y))
            return default;
        x.amount -= y.amount;
        return x;
    }

    public static CurrencyAmount operator *(CurrencyAmount x, decimal y)
    {
        x.amount *= y;
        return x;
    }

    public static CurrencyAmount operator /(CurrencyAmount x, decimal y)
    {
        x.amount /= y;
        return x;
    }

    public static implicit operator double(CurrencyAmount x) => (double)x.amount;

    public static implicit operator decimal(CurrencyAmount x) => x.amount;
}
