using System;

class BirdCount
{
    private static readonly int EMPTY_DAY = 0;
    private static readonly int BUSY_DAY = 5;

    private int[] _birdsPerDay;
    private int _todaysCount;

    public BirdCount(int[] birdsPerDay)
    {
        this._birdsPerDay = birdsPerDay;
        this._todaysCount = birdsPerDay.Length - 1;
    }

    public static int[] LastWeek() => new[] { 0, 2, 5, 3, 7, 8, 4 };

    public int Today() => this._birdsPerDay[this._todaysCount];

    public void IncrementTodaysCount() => this._birdsPerDay[this._todaysCount]++;

    public bool HasDayWithoutBirds() => Array.Exists(this._birdsPerDay, i => i == EMPTY_DAY);

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        foreach (int bird in this._birdsPerDay[0..numberOfDays])
        {
            count += bird;
        }
        return count;
    }

    public int BusyDays() => Array.FindAll(this._birdsPerDay, i => i >= BUSY_DAY).Length;
}
