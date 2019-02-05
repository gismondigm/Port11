namespace Port11.Models
{
    public class TestResult
    {
        public ServiceRequest ServiceRequest { get; set; }
        public bool IsPassed { get; set; }
        public bool IsUnavailable { get; set; }
        public bool IsPerformanceWarning { get; set; }
        public bool IsErrorMessages { get; set; }
        public double TestCaseTime { get; set; }
        public double ServiceTime { get; set; }
        public double PerformanceMonitorSecond { get; set; }
        public double RunTimeThreshold { get; set; }
        public double ElapsedTimeTestCase { get; set; }
        public double ExecutionTime { get; set; }
        public string PerformanceMonitor { get; set; }
        public string Ram { get; set; }
        public string Cpu { get; set; }
        public string OutputMessage { get; set; }
        public string Messages { get; set; }
    }
}
