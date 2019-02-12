using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Port11.Models;
using Port11.Utilities;
using RestSharp;
using UnitTests.ModelsForTesting;

namespace UnitTests
{
    [TestClass]
    public class StatusMethodTests : BaseUtilitiesUnitTest
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
        public void MethodPostTest()
        {
            var create = new Create
            {
                name = "Test",
                salary = "123",
                age = "456"
            };
            var serviceRequest = new ServiceRequest
            {
                Url = "/api/v1/create",
                Json = JsonHelper.GetJsonFromModel(create),
                Method = Method.POST,
                BaseUri = "http://dummy.restapiexample.com"
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);
            Verify.IsTrue(sendRequest.RestResponse.StatusCode == HttpStatusCode.OK, "Verify 200 Status Code");
        }
    }
}
