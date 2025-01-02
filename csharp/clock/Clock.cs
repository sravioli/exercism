using System;

public class Clock : IEquatable<Clock>
{
    private const int OneHour = 60;
    private const int OneDay = 24;

    private readonly int _minutes;
    private readonly int _hours;
    private readonly int _time;

    public Clock(int hours, int minutes = 0)
    {
        _time = (OneHour * hours + minutes) % (OneDay * OneHour);
        while (_time < 0)
            _time += OneDay * OneHour;

        _hours = _time / OneHour;
        _minutes = _time % OneHour;
    }

    public Clock Add(int minutesToAdd) => new(0, _time + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => Add(-minutesToSubtract);

    public override string ToString() => $"{_hours:D2}:{_minutes:D2}";

    public bool Equals(Clock other) =>
        other is not null
        && (ReferenceEquals(this, other) || _minutes == other._minutes && _hours == other._hours);

    public override bool Equals(object obj) =>
        obj is not null
        && (ReferenceEquals(this, obj) || obj.GetType() == GetType() && Equals((Clock)obj));

    public override int GetHashCode() => HashCode.Combine(_minutes, _hours);
}
