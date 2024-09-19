using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        string playerDescription;
        switch (shirtNum)
        {
            case 1:
                playerDescription = "goalie";
                break;
            case 2:
                playerDescription = "left back";
                break;
            case int num when num is 3 or 4:
                playerDescription = "center back";
                break;
            case 5:
                playerDescription = "right back";
                break;
            case int num when num is >= 6 and <= 8:
                playerDescription = "midfielder";
                break;
            case 9:
                playerDescription = "left wing";
                break;
            case 10:
                playerDescription = "striker";
                break;
            case 11:
                playerDescription = "right wing";
                break;

            default:
                throw new ArgumentOutOfRangeException($"Shirt number is outside 1-11 range.");
        }
        return playerDescription;
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int supportersNumber when report is int:
                return $"There are {supportersNumber} supporters at the match.";
            case string announcment when report is string:
                return announcment;
            case Incident incident when report is Incident:
                switch (incident)
                {
                    case Injury:
                        return $"Oh no! {incident.GetDescription()} Medics are on the field.";
                    default:
                        return incident.GetDescription();
                }
            case Manager manager when report is Manager:
                return $"{manager.Name}{(manager?.Club != null ? $" ({manager!.Club})" : $"")}";
            default:
                throw new ArgumentException("Unknown report to analyze");
        }
    }
}
