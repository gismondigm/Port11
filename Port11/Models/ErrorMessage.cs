using System;

namespace Port11.Models
{
    public class ErrorMessage
    {
        public string FailureReason { get; }
        public string StackTrace { get; }

        public ErrorMessage(Exception e)
        {
            FailureReason = Environment.NewLine + e.Message;
            StackTrace = e.StackTrace;
        }
        public ErrorMessage(string msg)
        {
            FailureReason = Environment.NewLine + msg;
            StackTrace = string.Empty;
        }
        public override string ToString()
        {
            var fullErrorMessage = "";

            fullErrorMessage += FailureReason;
            fullErrorMessage += "\r\n";
            fullErrorMessage += StackTrace;

            return fullErrorMessage;
        }
    }
}