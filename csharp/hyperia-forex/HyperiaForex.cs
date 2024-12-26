using System;

public struct CurrencyAmount(decimal amount, string currency)
{
    private readonly decimal _amount = amount;
    private readonly string _currency = currency;

    public static bool operator ==(CurrencyAmount x, CurrencyAmount y) =>
        AreCurrencyEqual(x, y) && x._currency == y._currency && x._amount == y._amount;

    public static bool operator !=(CurrencyAmount x, CurrencyAmount y) => !(x == y);

    public static bool operator >(CurrencyAmount x, CurrencyAmount y) =>
        AreCurrencyEqual(x, y) && x._amount > y._amount;

    public static bool operator <(CurrencyAmount x, CurrencyAmount y) =>
        AreCurrencyEqual(x, y) && x._amount < y._amount;

    public static CurrencyAmount operator +(CurrencyAmount x, CurrencyAmount y) =>
        NewWithAmount(x, y, x._amount + y._amount);

    public static CurrencyAmount operator -(CurrencyAmount x, CurrencyAmount y) =>
        NewWithAmount(x, y, x._amount - y._amount);

    public static CurrencyAmount operator *(CurrencyAmount x, decimal y) =>
        new(x._amount * y, x._currency);

    public static CurrencyAmount operator /(CurrencyAmount x, decimal y) =>
        new(x._amount / y, x._currency);

    public static implicit operator double(CurrencyAmount x) => (double)x._amount;

    public static implicit operator decimal(CurrencyAmount x) => x._amount;

    private static CurrencyAmount NewWithAmount(CurrencyAmount x, CurrencyAmount y, decimal amount)
    {
        return AreCurrencyEqual(x, y)
            ? new CurrencyAmount(amount: amount, currency: x._currency)
            : default;
    }

    private static bool AreCurrencyEqual(CurrencyAmount x, CurrencyAmount y) =>
        x._currency == y._currency ? true : throw new ArgumentException("Currency must be equal");
}
