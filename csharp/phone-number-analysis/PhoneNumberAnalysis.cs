using System;

public static class PhoneNumber
{
    private static readonly string DELIMITER = "-";
    private static readonly string NY_DIALING = "212";
    private static readonly string FAKE_PREFIX = "555";

    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        string[] elements = phoneNumber.Split(DELIMITER);
        return (elements[0] == NY_DIALING, elements[1] == FAKE_PREFIX, elements[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) =>
        phoneNumberInfo.IsFake;
}
