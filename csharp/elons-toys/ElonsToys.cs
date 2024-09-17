using System;

class RemoteControlCar
{
    private static readonly int DISTANCE_INCREMENT = 20;
    private static readonly int BATTERY_EMPTY_LVL = 0;
    private static readonly int BATTERY_FULL_LVL = 100;

    private static readonly string DISTANCE_FMT = "Driven {0} meters";
    private static readonly string BATTERY_FMT = "Battery at {0}%";
    private static readonly string BATTERY_EMPTY_ERR = "Battery empty";

    private int _distanceDriven;
    private int _batteryLevel = BATTERY_FULL_LVL;

    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => String.Format(DISTANCE_FMT, _distanceDriven);

    public string BatteryDisplay() =>
        String.Format(
            _batteryLevel == BATTERY_EMPTY_LVL ? BATTERY_EMPTY_ERR : BATTERY_FMT,
            _batteryLevel
        );

    public void Drive()
    {
        if (_batteryLevel > BATTERY_EMPTY_LVL)
        {
            _distanceDriven = _distanceDriven + DISTANCE_INCREMENT;
            _batteryLevel--;
        }
    }
}
