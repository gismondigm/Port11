using Microsoft.VisualStudio.TestTools.UnitTesting;
using Port11.Models;
using Port11.Utilities;
using RestSharp;
using System;
using System.Linq;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1 : BaseUnitTest
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
        public void StatusCode200Test()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/todos/1",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.OK, "Verify Status Code");
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
        [TestCategory("Unit"), TestMethod]
        public void VerifyStringsAreEqualTest()
        {
            const string stringFromService = "test";
            const string stringExpected = "test";
            Verify.Strings.AreEqual(stringFromService, stringExpected, "Testing Strings Are Equal");
        }
        [TestCategory("Unit"), TestMethod]
        public void VerifyStringsAreNotEqualTest()
        {
            const string stringFromService = "test";
            const string stringExpected = "test2";
            Verify.Strings.AreNotEqual(stringFromService, stringExpected, "Testing Strings Are NOT Equal");
        }
        [TestCategory("Unit"), TestMethod]
        public void VerifyStringsArePartiallyEqualTest()
        {
            const string stringFromTest = "test";
            const string stringExpected = "tes";
            Verify.Strings.ArePartiallyEqual(stringFromTest, stringExpected, "Testing Strings Are Patially Equal");
        }
        [TestCategory("Unit"), TestMethod]
        public void VerifyStringsArePartiallyEqualIgnoreCaseTest()
        {
            const string stringFromTest = "test";
            const string stringExpected = "Tes";
            Verify.Strings.ArePartiallyEqual(stringFromTest, stringExpected, "Testing Strings Are Patially Equal", ignoreCase: true);
        }
    }
}
