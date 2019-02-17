using Port11.Models;
using RestSharp;
using System;

namespace Port11.Utilities
{
    public class RestClientAuthenticator
    {
        public static Response SendRequest(ServiceRequest serviceRequest)
        {
            var client = RestClientGet(serviceRequest);
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
            var request = new RestRequest(serviceRequest.Url, serviceRequest.Method) { Timeout = 900000 };
            foreach (var header in serviceRequest.RequestHeaders)
            {
                request.AddHeader(header.Name, header.Value);
            }
            if (serviceRequest.Json != "")
            {
                request.AddParameter("application/json", serviceRequest.Json, ParameterType.RequestBody);
            }
            return request;
        }
        public static RestClient RestClientGet(ServiceRequest serviceRequest)
        {
            return new RestClient
            {
                BaseUrl = new Uri(serviceRequest.BaseUri)
            };
        }
    }
}