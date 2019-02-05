using System.Collections.Generic;
using Port11.Utilities;
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
        public List<ResponseHeader> ResponseHeaders = new List<ResponseHeader>();
        public bool ReturnAsJson { get; set; }
    }
}
