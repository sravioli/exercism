using System;

class WeighingMachine(int precision)
{
    private static readonly double DEFAULT_TARE = 5.0;

    public int Precision { get; } = precision;

    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = DEFAULT_TARE;

    public string DisplayWeight => string.Format($"{{0:F{Precision}}} kg", Weight - TareAdjustment);
}
