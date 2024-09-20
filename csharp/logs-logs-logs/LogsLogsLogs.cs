using System;

enum LogLevel
{
    Unknown,
    Trace,
    Debug,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
}

static class LogLine
{
    private static readonly string TRACE = "[TRC]:";
    private static readonly string DEBUG = "[DBG]:";
    private static readonly string INFO = "[INF]:";
    private static readonly string WARNING = "[WRN]:";
    private static readonly string ERROR = "[ERR]:";
    private static readonly string FATAL = "[FTL]:";

    public static LogLevel ParseLogLevel(string logLine)
    {
        switch (logLine)
        {
            case string when logLine.StartsWith(TRACE):
                return LogLevel.Trace;
            case string when logLine.StartsWith(DEBUG):
                return LogLevel.Debug;
            case string when logLine.StartsWith(INFO):
                return LogLevel.Info;
            case string when logLine.StartsWith(WARNING):
                return LogLevel.Warning;
            case string when logLine.StartsWith(ERROR):
                return LogLevel.Error;
            case string when logLine.StartsWith(FATAL):
                return LogLevel.Fatal;
            default:
                return LogLevel.Unknown;
        }
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) =>
        $"{(int)logLevel}:{message}";
}
