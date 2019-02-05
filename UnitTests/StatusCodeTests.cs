using Microsoft.VisualStudio.TestTools.UnitTesting;
using Port11.Models;
using Port11.Utilities;
using RestSharp;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class StatusCodeTests : BaseUnitTest
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
                Url = "/200",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.OK, "Verify Status Code");
        }
        [TestCategory("Unit"), TestMethod]
        public void StatusCode401Test()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/401",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.OK, "Verify Status Code");
        }
    }
}
