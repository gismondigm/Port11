using Port11.Enums;
using System;

namespace Port11.Models
{
    public class LogEntry
    {
        public DateTime EntryDateTime { get; }
        public string Message { get; }
        public ErrorMessage Error { get; }
        public LogLevel LogLevel { get; }
        public string AdditionalInfo { get; }


        internal LogEntry(string msg, LogLevel logLevel)
        {
            Message = msg;
            LogLevel = logLevel;
            EntryDateTime = DateTime.Now;
        }
        internal LogEntry(string msg, LogLevel logLevel, string additionalInfo)
        {
            Message = msg;
            LogLevel = logLevel;
            AdditionalInfo = additionalInfo;
            EntryDateTime = DateTime.Now;
        }

        internal LogEntry(string msg, ErrorMessage error, LogLevel logLevel)
        {
            Message = msg;
            Error = error;
            LogLevel = logLevel;
            EntryDateTime = DateTime.Now;
        }
    }
}
