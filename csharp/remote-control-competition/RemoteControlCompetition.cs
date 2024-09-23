using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    void Drive();

    int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    private const int OBJ_GREATER = 1;

    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(ProductionRemoteControlCar other)
    {
        if (other == null)
        {
            return OBJ_GREATER;
        }
        return NumberOfVictories - other.NumberOfVictories;
    }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car) => car.Drive();

    public static List<ProductionRemoteControlCar> GetRankedCars(
        ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2
    )
    {
        List<ProductionRemoteControlCar> rankedCars = new List<ProductionRemoteControlCar>([prc1, prc2]);
        rankedCars.Sort();
        return rankedCars;
    }
}
