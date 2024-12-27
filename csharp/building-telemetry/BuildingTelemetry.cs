public class RemoteControlCar
{
    private int _batteryPercentage = 100;
    private int _distanceDrivenInMeters;
    private string[] _sponsors = [];
    private int _latestSerialNum;

    public void Drive()
    {
        if (_batteryPercentage <= 0)
            return;
        _batteryPercentage -= 10;
        _distanceDrivenInMeters += 2;
    }

    public void SetSponsors(params string[] sponsors) => _sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) => _sponsors[sponsorNum];

    public bool GetTelemetryData(
        ref int serialNum,
        out int batteryPercentage,
        out int distanceDrivenInMeters
    )
    {
        if (serialNum < _latestSerialNum)
        {
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            serialNum = _latestSerialNum;
            return false;
        }

        batteryPercentage = _batteryPercentage;
        distanceDrivenInMeters = _distanceDrivenInMeters;
        _latestSerialNum = serialNum;
        return true;
    }

    public int GetDistanceDriven() => _distanceDrivenInMeters;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient(RemoteControlCar car)
{
    public string GetBatteryUsagePerMeter(int serialNum)
    {
        var isSuccessful = car.GetTelemetryData(ref serialNum, out var battery, out var distance);
        if (!isSuccessful || distance == 0)
        {
            return "no data";
        }
        return $"usage-per-meter={(100 - battery) / distance}";
    }
}
