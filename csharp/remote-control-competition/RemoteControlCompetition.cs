using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    void Drive();

    int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(ProductionRemoteControlCar other) =>
        other == null ? 1 : NumberOfVictories - other.NumberOfVictories;

    public void Drive() => DistanceTravelled += 10;
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive() => DistanceTravelled += 20;
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car) => car.Drive();

    public static List<ProductionRemoteControlCar> GetRankedCars(
        ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2
    )
    {
        List<ProductionRemoteControlCar> rankedCars = [prc1, prc2];
        rankedCars.Sort();
        return rankedCars;
    }
}
