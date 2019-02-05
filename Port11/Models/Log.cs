using Port11.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Port11.Models
{
    public static class Log
    {
        public static List<LogEntry> LogEntries;

        public static int Count => LogEntries?.Count ?? 0;

        public static int ErrorCount
        {
            get { return LogEntries.Count(logRecord => logRecord.LogLevel == LogLevel.Error); }
        }

        public static int FailCount
        {
            get { return LogEntries.Count(logRecord => logRecord.LogLevel == LogLevel.Fail); }
        }

        public static int WarningCount
        {
            get { return LogEntries.Count(logRecord => logRecord.LogLevel == LogLevel.Warning); }
        }

        public static void Initialize()
        {
            LogEntries = new List<LogEntry>();
        }

        public static void Write(string msg)
        {
            Console.WriteLine(msg);
            var line = new LogEntry(msg, LogLevel.Info);
            LogEntries.Add(line);
        }

        public static void Info(string msg)
        {
            Write(msg);
            Console.WriteLine();
        }

        public static void Warning(string msg)
        {
            Console.WriteLine(@"
 WARNING: " + msg);
            Console.WriteLine();
            var line = new LogEntry(msg, LogLevel.Warning);
            LogEntries.Add(line);
        }

        public static void Pass(string msg, string passReason)
        {
            Console.WriteLine(@"
 Passed: " + passReason);
            Console.WriteLine();
            var line = new LogEntry(msg, LogLevel.Pass, passReason);
            LogEntries.Add(line);
        }


        public static void Fail(string msg, ErrorMessage error)
        {
            Console.WriteLine(@"
 FAILED: " + error.FailureReason);
            Console.WriteLine();
            var line = new LogEntry(msg, error, LogLevel.Fail);
            LogEntries.Add(line);
        }


        public static void Error(string msg, ErrorMessage error)
        {

            Console.WriteLine(@"
! ERROR: " + error.FailureReason);
            if (!string.IsNullOrEmpty(error.StackTrace))
            {
                Console.WriteLine(@"
 Stack Trace: " + error.StackTrace);
            }

            var line = new LogEntry(msg + " - " + error.FailureReason, error, LogLevel.Error);
            LogEntries.Add(line);

            Console.WriteLine();
        }

        public static void Error(ErrorMessage error)
        {
            Console.WriteLine(@"
! ERROR: " + error.FailureReason);
            if (!string.IsNullOrEmpty(error.StackTrace))
            {
                Console.WriteLine(@"
 Stack Trace: " + error.StackTrace);
            }

            var line = new LogEntry(error.FailureReason, error, LogLevel.Error);
            LogEntries.Add(line);

            Console.WriteLine();
        }

        public static void Error(string msg)
        {
            var error = new ErrorMessage(msg);

            Console.WriteLine(@"
! ERROR: " + error.FailureReason);
            if (!string.IsNullOrEmpty(error.StackTrace))
            {
                Console.WriteLine(@"
 Stack Trace: " + error.StackTrace);
            }

            var line = new LogEntry(error.FailureReason, error, LogLevel.Error);
            LogEntries.Add(line);

            Console.WriteLine();
        }
    }
}
