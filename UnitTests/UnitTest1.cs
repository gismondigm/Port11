using Microsoft.VisualStudio.TestTools.UnitTesting;
using Port11.Models;
using Port11.Utilities;
using RestSharp;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var serviceRequest = new ServiceRequest
            {
                Url = "/todos/1",
                Json = "",
                Method = Method.GET
            };
            var sendRequest = RestClientAuthenticator.SendRequest(serviceRequest);

        }
    }
}
