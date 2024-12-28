public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    public TelemetryHandler Telemetry { get; private set; }
    private Speed _currentSpeed;

    public RemoteControlCar() => Telemetry = new TelemetryHandler(this);

    public class TelemetryHandler(RemoteControlCar car)
    {
        private RemoteControlCar Car { get; } = car;

        public void Calibrate() { }

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName) => Car.SetSponsor(sponsorName);

        public void SetSpeed(decimal amount, string unitsString)
        {
            var speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }
            Car.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public string GetSpeed() => _currentSpeed.ToString();

    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;

    private void SetSpeed(Speed speed) => _currentSpeed = speed;
}

internal enum SpeedUnits
{
    MetersPerSecond = 0,
    CentimetersPerSecond = 1,
}

internal readonly struct Speed(decimal amount, SpeedUnits speedUnits)
{
    private decimal Amount { get; } = amount;
    private SpeedUnits SpeedUnits { get; } = speedUnits;

    public override string ToString()
    {
        var unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }
        return Amount + " " + unitsString;
    }
}
