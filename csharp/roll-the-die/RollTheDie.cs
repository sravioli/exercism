using System;

public class Player
{
    private static readonly Random rnd = new Random();

    private static readonly int MIN_ROLL = 1;
    private static readonly int MAX_ROLL = 18;

    public int RollDie() => rnd.Next(MIN_ROLL, MAX_ROLL);

    public double GenerateSpellStrength() => rnd.NextDouble() * 100;
}
