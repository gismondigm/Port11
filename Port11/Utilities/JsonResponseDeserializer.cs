using System.Web.Script.Serialization;
namespace Port11.Utilities
{
    public class JsonResponseDeserializer
    {
        public static JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer { MaxJsonLength = 2147483644 };
        public static dynamic Deserialize(string input)
        {
            return JavaScriptSerializer.Deserialize<dynamic>(input);
        }
    }
}