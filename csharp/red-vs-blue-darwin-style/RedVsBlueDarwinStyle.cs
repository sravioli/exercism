namespace RedRemoteControlCarTeam
{
    public class RemoteControlCar
    {
        public RemoteControlCar(
            Motor motor,
            Chassis chassis,
            Telemetry telemetry,
            RunningGear runningGear
        ) { }
        // red members and API
    }

    public class RunningGear
    {
        // red members and API
    }

    public class Telemetry
    {
        // red members and API
    }

    public class Chassis
    {
        // red members and API
    }

    public class Motor
    {
        // red members and API
    }
}

namespace BlueRemoteControlCarTeam
{
    public class RemoteControlCar
    {
        public RemoteControlCar(Motor motor, Chassis chassis, Telemetry telemetry) { }
        // blue members and API
    }

    public class Telemetry
    {
        // blue members and API
    }

    public class Chassis
    {
        // blue members and API
    }

    public class Motor
    {
        // blue members and API
    }
}

namespace Combined
{
    using BlueTeam = BlueRemoteControlCarTeam;
    using RedTeam = RedRemoteControlCarTeam;

    public static class CarBuilder
    {
        public static RedTeam.RemoteControlCar BuildRed()
        {
            return new RedTeam.RemoteControlCar(
                new RedTeam.Motor(),
                new RedTeam.Chassis(),
                new RedTeam.Telemetry(),
                new RedTeam.RunningGear()
            );
        }

        public static BlueTeam.RemoteControlCar BuildBlue()
        {
            return new BlueTeam.RemoteControlCar(
                new BlueTeam.Motor(),
                new BlueTeam.Chassis(),
                new BlueTeam.Telemetry()
            );
        }
    }
}
