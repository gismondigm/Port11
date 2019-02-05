using System;
using Port11.Models;
using RestSharp;

namespace Port11.Utilities
{
    public class RestClientAuthenticator
    {
        public static Response SendRequest(ServiceRequest serviceRequest)
        {
            var client = RestClientGet();
            var request = RequestHeadersSet(serviceRequest);
            double tickStart = Environment.TickCount;
            var response = client.Execute(request);
            double tickEnd = Environment.TickCount;
            var testCaseTime = (tickEnd - tickStart) / 1000;
            var sendRequest = new Response();
            {
                sendRequest.RestResponse = response;
                sendRequest.ExecutionTime = testCaseTime;
            }
            return sendRequest;
        }

        public static RestRequest RequestHeadersSet(ServiceRequest serviceRequest)
        {
            var request = new RestRequest(serviceRequest.Url, serviceRequest.Method) {Timeout = 900000};
            foreach (var header in serviceRequest.ResponseHeaders)
            {
                request.AddHeader(header.Name, header.Value);
            }
            return request;
        }
        public static RestClient RestClientGet(string token = "", string tokenAzure = "")
        {
            return new RestClient
            {
                //todo: get uri from settings
                BaseUrl = new Uri("https://jsonplaceholder.typicode.com")
            };
        }
    }
}
