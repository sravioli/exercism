public class SpaceAge(int seconds)
{
    private const double MercuryOrbitalPeriodInEarthYears = 0.2408467;
    private const double VenusOrbitalPeriodInEarthYears = 0.61519726;
    private const double MarsOrbitalPeriodInEarthYears = 1.8808158;
    private const double JupiterOrbitalPeriodInEarthYears = 11.862615;
    private const double SaturnOrbitalPeriodInEarthYears = 29.447498;
    private const double UranusOrbitalPeriodInEarthYears = 84.016846;
    private const double NeptuneOrbitalPeriodInEarthYears = 164.79132;
    private const double OneYearInSeconds = 3.15576e+7;

    private double CalculateAge(double orbitalPeriod = 1.0) =>
        seconds / (OneYearInSeconds * orbitalPeriod);

    public double OnEarth() => CalculateAge();

    public double OnMercury() => CalculateAge(MercuryOrbitalPeriodInEarthYears);

    public double OnVenus() => CalculateAge(VenusOrbitalPeriodInEarthYears);

    public double OnMars() => CalculateAge(MarsOrbitalPeriodInEarthYears);

    public double OnJupiter() => CalculateAge(JupiterOrbitalPeriodInEarthYears);

    public double OnSaturn() => CalculateAge(SaturnOrbitalPeriodInEarthYears);

    public double OnUranus() => CalculateAge(UranusOrbitalPeriodInEarthYears);

    public double OnNeptune() => CalculateAge(NeptuneOrbitalPeriodInEarthYears);
}
