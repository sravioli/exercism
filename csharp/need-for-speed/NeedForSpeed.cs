using System;

class RemoteControlCar
{
    private static readonly int NITRO_SPEED = 50;
    private static readonly int NITRO_BATTERY_DRAIN = 4;
    private static readonly int MIN_BATTERY = 0;

    private int _speed;
    private int _batteryDrain;
    private int _metersDriven = 0;
    private int _batteryLevel = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this._speed = speed;
        this._batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() =>
        this._batteryLevel == MIN_BATTERY || this._batteryLevel < this._batteryDrain;

    public int DistanceDriven() => this._metersDriven;

    public void Drive()
    {
        if (!BatteryDrained())
        {
            this._metersDriven += this._speed;
            this._batteryLevel -= this._batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() =>
        new RemoteControlCar(NITRO_SPEED, NITRO_BATTERY_DRAIN);
}

class RaceTrack
{
    private int _distance;

    public RaceTrack(int distance)
    {
        this._distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained() && car.DistanceDriven() <= this._distance)
        {
            car.Drive();
        }
        return car.DistanceDriven() >= this._distance;
    }
}
