using System;

class BirdCount
{
    private static readonly int EMPTY_DAY = 0;
    private static readonly int BUSY_DAY = 5;
    private static readonly int[] lastWeekCount = new[] { 0, 2, 5, 3, 7, 8, 4 };

    private int[] _birdsPerDay;

    public BirdCount(int[] birdsPerDay) => this._birdsPerDay = birdsPerDay;

    public static int[] LastWeek() => lastWeekCount;

    public int Today() => this._birdsPerDay[^1];

    public void IncrementTodaysCount() => this._birdsPerDay[^1]++;

    public bool HasDayWithoutBirds() => Array.Exists(this._birdsPerDay, i => i == EMPTY_DAY);

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        foreach (int bird in this._birdsPerDay[0..numberOfDays])
        {
            count = count + bird;
        }
        return count;
    }

    public int BusyDays() => Array.FindAll(this._birdsPerDay, i => i >= BUSY_DAY).Length;
}
