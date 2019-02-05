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
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.OK, "Verify 200 Status Code");
        }
        [TestCategory("Unit"), TestMethod]
        public void StatusCode400Test()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/400",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.BadRequest, "Verify 400 Status Code");
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
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.Unauthorized, "Verify 401 Status Code");
        }
        [TestCategory("Unit"), TestMethod]
        public void StatusCode403Test()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/403",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.Forbidden, "Verify 403 Status Code");
        }
        [TestCategory("Unit"), TestMethod]
        public void StatusCode404Test()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/404",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.NotFound, "Verify 404 Status Code");
        }
        [TestCategory("Unit"), TestMethod]
        public void StatusCode405Test()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/405",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.MethodNotAllowed, "Verify 405 Status Code");
        }
        [TestCategory("Unit"), TestMethod]
        public void StatusCode500Test()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/500",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.InternalServerError, "Verify 500 Status Code");
        }
        [TestCategory("Unit"), TestMethod]
        public void StatusCode502Test()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/502",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.BadGateway, "Verify 502 Status Code");
        }
        [TestCategory("Unit"), TestMethod]
        public void StatusCode503Test()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/503",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.ServiceUnavailable, "Verify 503 Status Code");
        }
    }
}
