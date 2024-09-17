using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string dep = department?.ToUpper() ?? "OWNER";
        if (id == null) {
            return $"{name} - {dep}";
        }
        return $"[{id}] - {name} - {dep}";
    }
}
