using System;

static class AssemblyLine
{
    private static readonly int BASE_PRODUCTION_SPEED = 221;
    
    public static double SuccessRate(int speed)
    {
        double successRate = 1;
        if (speed == 0) {
            successRate = 0.0;
        } else if (speed == 10) {
            successRate = 0.77;
        } else if (speed == 9) {
            successRate = 0.80;
        } else if (speed >= 5 && speed <= 8) {
            successRate = 0.90;
        }
        return successRate;
    }
    
    public static double ProductionRatePerHour(int speed) => 
        speed * BASE_PRODUCTION_SPEED * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) =>
        (int)ProductionRatePerHour(speed) / 60;
}
