using SX.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SX.Shared.Models
{
    public class LogResult
    {
        public List<LogMessage> Messages { get; protected set; }

        public LogResult() { this.Messages = new List<LogMessage>(); }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var message in this.Messages)
                sb.AppendLine(message.ToString());
            return sb.ToString();
        }

        public void Add(LogMessageType type, string message)
        {
            if (type == LogMessageType.Error || !String.IsNullOrEmpty(message))
                this.Messages.Add(new LogMessage(type, message));
        }
        public void Add(string message) => Add(LogMessageType.Info, message);
        public void AddError(string error) => Add(LogMessageType.Error, error);
        public void AddInfo(string info) => Add(LogMessageType.Info, info);
        public void Add(bool correct, string message) => Add(correct ? LogMessageType.Info : LogMessageType.Error, message);
    }
}
