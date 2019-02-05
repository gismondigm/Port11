using Microsoft.VisualStudio.TestTools.UnitTesting;
using Port11.Models;
using Port11.Utilities;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class HelperTests : BaseUnitTest
    {
        [ClassInitialize]
        public static void TestClassinitialize(TestContext context)
        {
            SetSettings(context);
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
        public void ThinkBetweenCallsTest()
        {
            var tickStart = Environment.TickCount;
            Helper.ThinkBetweenCalls();
            var tickEnd = Environment.TickCount;
            var testCaseTime = (tickEnd - tickStart) / 1000;
            Verify.IsTrue(Enumerable.Range(3, 8).Contains(testCaseTime), "Verify Test Case Time is Within Range");
        }
    }
}
