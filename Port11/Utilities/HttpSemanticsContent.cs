namespace Port11.Utilities
{
    public class HttpSemanticsContent
    {
        public static string GetMultiStatus()
        {
            return "The 207 (MULTI-STATUS) status code conveys information about multiple resources in situations where multiple status codes might be appropriate.";
        }
        public static string GetBadRequest()
        {
            return "The 400 (Bad Request) status code indicates that the server cannot or will not process the request due to something that is perceived to be a client error (e.g., malformed request syntax, invalid request message framing, or deceptive request routing).";
        }
        public static string GetUnauthorized()
        {
            return "The 401 (Unauthorized) status code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.";
        }
        public static string GetForbidden()
        {
            return "The 403 (Forbidden) status code indicates that the server understood the request but refuses to authorize it.A server that wishes to make public why the request has been forbidden can describe that reason in the response payload(if any).";
        }
        public static string GetNotFound()
        {
            return "The 404 (Not Found) status code indicates that the origin server did not find a current representation for the target resource or is not willing to disclose that one exists.A 404 status code does not indicate whether this lack of representation is temporary or permanent; the 410(Gone) status code is preferred over 404 if the origin server knows, presumably through some configurable means, that the condition is likely to be permanent.";
        }
        public static string GetMethodNotAllowed()
        {
            return "The 405 (Method Not Allowed) status code indicates that the method received in the request-line is known by the origin server but not supported by the target resource.  The origin server MUST generate an Allow header field in a 405 response containing a list of the target resource's currently supported methods.";
        }
        public static string GetLocked()
        {
            return "The 423 (LOCKED) status code indicates that the source or destination resource of a method is locked.";
        }
        public static string GetInternalServerError()
        {
            return "The 500 (Internal Server Error) status code indicates that the server encountered an unexpected condition that prevented it from fulfilling the request.";
        }
        public static string GetBadGateway()
        {
            return "The 502 (Bad Gateway) status code indicates that the server, while acting as a gateway or proxy, received an invalid response from an inbound server it accessed while attempting to fulfill the request.";
        }
        public static string GetServiceUnavailable()
        {
            return "The 503 (Service Unavailable) status code indicates that the server is currently unable to handle the request due to a temporary overload or scheduled maintenance, which will likely be alleviated after some delay.The server MAY send a Retry-After header field to suggest an appropriate amount of time for the client to wait before retrying the request.";
        }
    }
}
