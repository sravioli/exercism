class Lasagna
{
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int elapsedTime) =>
        this.ExpectedMinutesInOven() - elapsedTime;

    public int PreparationTimeInMinutes(int layers) => layers * 2;

    public int ElapsedTimeInMinutes(int layers, int timeInOven) =>
        this.PreparationTimeInMinutes(layers) + timeInOven;
}
