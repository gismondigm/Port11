using System.Collections.Generic;
using RestSharp;

namespace Port11.Models
{
    public class ServiceRequest
    {
        public string Service { get; set; }
        public string Url { get; set; }
        public string Json { get; set; }
        public Method Method { get; set; }
        public string TestName { get; set; }
        public List<Header> RequestHeaders = SetDefaultRequestHeaders();
        public bool ReturnAsJson = true;
        public string BaseUri { get; set; }

        public static List<Header> SetDefaultRequestHeaders()
        {
            return new List<Header>
            {
                new Header { Name = "Content-Type", Value = "application/json;charset=UTF-8" },
                new Header { Name = "Accept", Value = "application/json, text/plain, */*" }
            };
        }
    }
}
