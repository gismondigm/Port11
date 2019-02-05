using System;
using RestSharp;
namespace Port11
{
    public class ServiceRequest
    {
        public string Service { get; set; }
        public string Url { get; set; }
        public string Json { get; set; }
        public Method Method { get; set; }
        public string TestName { get; set; }
    }
}
