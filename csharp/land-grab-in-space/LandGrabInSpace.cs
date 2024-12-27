using System;
using System.Collections.Generic;

public readonly struct Coord(ushort x, ushort y)
{
    private ushort X { get; } = x;
    private ushort Y { get; } = y;

    public ushort Sum() => (ushort)(X + Y);

    public bool Equals(Coord other) => X == other.X && Y == other.Y;

    public override bool Equals(object obj) => obj is Coord other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y);
}

public readonly struct Plot(Coord nw, Coord ne, Coord sw, Coord se)
    : IComparable<Plot>,
        IEquatable<Plot>
{
    private Coord NorthWest { get; } = nw;
    private Coord NorthEast { get; } = ne;
    private Coord SouthWest { get; } = sw;
    private Coord SouthEast { get; } = se;

    private int Sum() => NorthWest.Sum() + NorthEast.Sum() + SouthWest.Sum() + SouthEast.Sum();

    public bool Equals(Plot other) =>
        NorthWest.Equals(other.NorthWest)
        && NorthEast.Equals(other.NorthEast)
        && SouthWest.Equals(other.SouthWest)
        && SouthEast.Equals(other.SouthEast);

    public int CompareTo(Plot other) => Sum() - other.Sum();

    public override bool Equals(object obj) => obj is Plot other && Equals(other);

    public override int GetHashCode() =>
        HashCode.Combine(NorthWest, NorthEast, SouthWest, SouthEast);

    public static bool operator ==(Plot left, Plot right) => left.Equals(right);

    public static bool operator !=(Plot left, Plot right) => !(left == right);
}

public class ClaimsHandler
{
    private static readonly List<Plot> ClaimedPlots = [];

    public static void StakeClaim(Plot plot) => ClaimedPlots.Add(plot);

    public static bool IsClaimStaked(Plot plot) => ClaimedPlots.Contains(plot);

    public static bool IsLastClaim(Plot plot) => ClaimedPlots[^1].Equals(plot);

    public static Plot GetClaimWithLongestSide()
    {
        ClaimedPlots.Sort();
        return ClaimedPlots[^1];
    }
}
