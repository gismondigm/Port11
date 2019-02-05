using System.Diagnostics;
namespace Port11.Models
{
    public class CpuUsage
    {
        private static PerformanceCounter _cpuCounter;
        private static PerformanceCounter _ramCounter;

        public static string GetCurrentCpuUsage()
        {
            _cpuCounter = new PerformanceCounter
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = "_Total"
            };
            _cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            return _cpuCounter.NextValue() + "%";
        }

        public static string GetAvailableRam()
        {
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            return _ramCounter.NextValue() + "MB";
        }
    }
}
