using SX.Shared.Enums;
using System;

namespace SX.Shared.Models
{
    public class LogMessage
    {
        public DateTimeOffset Date { get; protected set; }
        public LogMessageType Type { get; protected set; }
        public string Message { get; protected set; }

        public LogMessage(LogMessageType type, string message = "")
        {
            Date = Helpers.GetDateTimeOffset();
            Type = type;
            Message = message ?? "";
        }

        public override string ToString() => $"{Date.ToString("yyyy-MM-dd HH:mm:ss")} \t [{Type}] \t {Message}";

        public static LogMessage Info(string message) => new LogMessage(LogMessageType.Info, message);
        public static LogMessage Warning(string message) => new LogMessage(LogMessageType.Warning, message);
        public static LogMessage Error(string message) => new LogMessage(LogMessageType.Error, message);
    }
}
