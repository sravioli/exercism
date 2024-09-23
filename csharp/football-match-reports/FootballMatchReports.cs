using System;

public static class PlayAnalyzer
{
    private const int GOALIE = 1;
    private const int LEFT_BACK = 2;
    private const int CENTER_BACK1 = 3;
    private const int CENTER_BACK2 = 4;
    private const int RIGHT_BACK = 5;
    private const int MIDFIELDER_MIN = 6;
    private const int MIDFIELDER_MAX = 8;
    private const int LEFT_WING = 9;
    private const int STRIKER = 10;
    private const int RIGHT_WING = 11;

    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case GOALIE:
                return "goalie";
            case LEFT_BACK:
                return "left back";
            case int num when num is CENTER_BACK1 or CENTER_BACK2:
                return "center back";
            case RIGHT_BACK:
                return "right back";
            case int num when num is >= MIDFIELDER_MIN and <= MIDFIELDER_MAX:
                return "midfielder";
            case LEFT_WING:
                return "left wing";
            case STRIKER:
                return "striker";
            case RIGHT_WING:
                return "right wing";

            default:
                throw new ArgumentOutOfRangeException("Shirt number is outside 1-11 range.");
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int supportersNumber:
                return $"There are {supportersNumber} supporters at the match.";
            case string announcment:
                return announcment;
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            case Incident incident:
                return incident.GetDescription();
            case Manager manager:
                return $"{manager.Name}{(manager?.Club != null ? $" ({manager!.Club})" : string.Empty)}";
            default:
                throw new ArgumentException("Unknown report to analyze");
        }
    }
}
