using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Port11.Models;
using Port11.Utilities;
using RestSharp;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class HelperTests : BaseUtilitiesUnitTest
    {
        [ClassInitialize]
        public static void TestClassinitialize(TestContext context)
        {
        }
        [TestCleanup]
        public void TearDown()
        {
            FinalizeTest(TestContext);
        }
        [TestCategory("Unit"), TestMethod]
        public void CurrentCpuUsageTest()
        {
            var currentCpuUsage = CpuUsage.GetCurrentCpuUsage();
            Verify.Strings.ArePartiallyEqual(currentCpuUsage, "%", "Verify that percentage is returned");
        }
        [TestCategory("Unit"), TestMethod]
        public void AvailableRamTest()
        {
            var availableRam = CpuUsage.GetAvailableRam();
            Verify.Strings.ArePartiallyEqual(availableRam, "MB", "Verify that MB is returned");
        }
        [TestCategory("Unit"), TestMethod]
        public void EpochTimeTest()
        {
            Assert.IsTrue(Helper.GetCurrentEpochTime() != 0, "Verify that EpochDate is not null");
        }
        [TestCategory("Unit"), TestMethod]
        public void EpochTimeFromDateTimeTest()
        {
            Assert.IsTrue(Helper.GetEpochTimeFromDateTime(DateTime.Now.AddDays(1)) != 0, "Verify that EpochDate is not null");
        }
        [TestCategory("Unit"), TestMethod]
        public void EpochTimeJsonTest()
        {
            var currentEpochJsonString = Helper.GetCurrentEpochJsonString();
            Verify.Strings.ArePartiallyEqual(currentEpochJsonString, "/Date(", "Verify Date String");
        }
        [TestCategory("Unit"), TestMethod]
        public void EpochTimeJsonDateTimeTest()
        {
            var currentEpochJsonString = Helper.GetEpochJsonStringFromDateTime(DateTime.Now.AddDays(-1));
            Verify.Strings.ArePartiallyEqual(currentEpochJsonString, "/Date(", "Verify Date String");
        }
        [TestCategory("Unit"), TestMethod]
        public void CamelCaseTest()
        {
            var input = "ThisIsTestingSplitCamelCase";
            var splitCamelCase = Helper.SplitCamelCase(input);
            Verify.Strings.AreEqual(splitCamelCase, "This Is Testing Split Camel Case", "Verify Split Camel Case");
        }
        [TestCategory("Unit"), TestMethod]
        public void IsNumericTest()
        {
            var isNumeric = Helper.IsNumeric("3");
            var isntNumeric = Helper.IsNumeric("a");
            Verify.IsTrue(isNumeric, "Verify is Numeric");
            Verify.IsFalse(isntNumeric, "Verify isnt Numeric");
        }
        [TestCategory("Unit"), TestMethod]
        public void WaitTest()
        {
            var tickStart = Environment.TickCount;
            Helper.Wait(2);
            var tickEnd = Environment.TickCount;
            var testCaseTime = (tickEnd - tickStart) / 1000;
            Verify.IsTrue(Enumerable.Range(1, 3).Contains(testCaseTime), "Verify Test Case Time is Within Range");
        }
        [TestCategory("Unit"), TestMethod]
        public void RandomNumberTest()
        {
            var number = Helper.GetRandomNumber(1, 10);
            Verify.IsTrue(Enumerable.Range(1, 10).Contains(number), "Verify Random Number is Within Range");
        }
        [TestCategory("Unit"), TestMethod]
        public void PropertyTest()
        {
            //todo
        }
        [TestCategory("Unit"), TestMethod]
        public void JsonHelperTest()
        {
            var performanceInformation = new PerformanceInformation
            {
                PerformanceMonitorSecond = 1,
                RunTimeThreshold = 2,
                ElapsedTimeTestCase = 3,
                ExecutionTime = 4,
                PerformanceMonitor = "PM",
                Ram = "ram",
                Cpu = "cpu"
            };
            var jsonFromModel = JsonHelper.GetJsonFromModel(performanceInformation);
            Verify.IsTrue(JsonHelper.IsValidJson(jsonFromModel), "Verify Is Valid Json");
        }
    }
}
