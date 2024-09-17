using System;

static class Appointment
{
    private static readonly int AFTERNOON_START = 12;
    private static readonly int AFTERNOON_END = 18;
    private static readonly DateTime ANNIVERSARY = new DateTime(DateTime.Now.Year, 9, 15);

    public static DateTime Schedule(string appointmentDateDescription) =>
        DateTime.Parse(appointmentDateDescription);

    public static bool HasPassed(DateTime appointmentDate) => DateTime.Now > appointmentDate;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) =>
        appointmentDate.Hour >= AFTERNOON_START && appointmentDate.Hour < AFTERNOON_END;

    public static string Description(DateTime appointmentDate) =>
        $"You have an appointment on {appointmentDate}.";

    public static DateTime AnniversaryDate() => ANNIVERSARY;
}
