using System;

public class Player
{
    private static readonly int MIN_ROLL = 1;
    private static readonly int MAX_ROLL = 19;
    private Random _rnd = new Random();

    public int RollDie() => _rnd.Next(MIN_ROLL, MAX_ROLL);

    public double GenerateSpellStrength() => _rnd.NextDouble() * 100;
}
