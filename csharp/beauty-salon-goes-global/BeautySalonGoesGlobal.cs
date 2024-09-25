using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Microsoft.VisualBasic;

public enum Location
{
    NewYork,
    London,
    Paris,
}

public enum AlertLevel
{
    Early = 86_400,
    Standard = 6_300,
    Late = 1_800,
}

public static class Appointment
{
    private static readonly bool IS_UNIX =
        (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS()) && !OperatingSystem.IsWindows();

    private static readonly Dictionary<
        Location,
        (TimeZoneInfo timeZone, CultureInfo cultureInfo)
    > TIMEZONES_IDS =
        new()
        {
            [Location.NewYork] = (
                TimeZoneInfo.FindSystemTimeZoneById(
                    IS_UNIX ? "America/New_York" : "Eastern Standard Time"
                ),
                CultureInfo.GetCultureInfo("en-US")
            ),
            [Location.London] = (
                TimeZoneInfo.FindSystemTimeZoneById(
                    IS_UNIX ? "Europe/London" : "GMT Standard Time"
                ),
                CultureInfo.GetCultureInfo("en-GB")
            ),
            [Location.Paris] = (
                TimeZoneInfo.FindSystemTimeZoneById(
                    IS_UNIX ? "Europe/Paris" : "W. Europe Standard Time"
                ),
                CultureInfo.GetCultureInfo("fr-FR")
            ),
        };

    private static readonly int MAX_DAYLIGHT_CHANGES_DAYS = 7;

    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) =>
        TimeZoneInfo.ConvertTimeToUtc(
            DateTime.Parse(appointmentDateDescription),
            TIMEZONES_IDS[location].timeZone
        );

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        appointment.AddSeconds(-(int)alertLevel);

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo tz = TIMEZONES_IDS[location].timeZone;
        bool isDaylightSavingTime = tz.IsDaylightSavingTime(dt);
        if (!isDaylightSavingTime)
        {
            for (var i = 0; i <= MAX_DAYLIGHT_CHANGES_DAYS && !isDaylightSavingTime; i++)
            {
                isDaylightSavingTime = tz.IsDaylightSavingTime(dt.AddDays(-i));
            }
        }
        return isDaylightSavingTime;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo cultureInfo = TIMEZONES_IDS[location].cultureInfo;
        return DateTime.TryParse(dtStr, cultureInfo, DateTimeStyles.None, out DateTime dt)
            ? dt
            : DateTime.MinValue;
    }
}
