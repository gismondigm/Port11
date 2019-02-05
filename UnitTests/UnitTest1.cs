using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Port11.Models;
using Port11.Utilities;
using RestSharp;

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
        [TestMethod]
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
    }
}
