using System;
using System.Globalization;

static class Appointment
{
    private static readonly string APPOINTMENT_FMT = "M/d/yyyy h:mm:ss tt";

    private static readonly TimeSpan AFTERNOON_START = new TimeSpan(12, 0, 0);
    private static readonly TimeSpan AFTERNOON_END = new TimeSpan(18, 0, 0);

    public static DateTime Schedule(string appointmentDateDescription) =>
        DateTime.Parse(appointmentDateDescription, CultureInfo.CurrentCulture);

    public static bool HasPassed(DateTime appointmentDate) =>
        appointmentDate.CompareTo(DateTime.Now) < 0;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) =>
        appointmentDate.TimeOfDay >= AFTERNOON_START && appointmentDate.TimeOfDay < AFTERNOON_END;

    public static string Description(DateTime appointmentDate) =>
        $"You have an appointment on {appointmentDate.ToString(APPOINTMENT_FMT)}.";

    public static DateTime AnniversaryDate() => new DateTime(DateTime.Now.Year, 9, 15);
}
