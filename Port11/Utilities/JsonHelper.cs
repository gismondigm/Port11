using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Port11.Models;
using System;

namespace Port11.Utilities
{
    public class JsonHelper
    {
        public static string GetJsonFromModel(object model, bool ignoreNulls = false)
        {
            try
            {
                if (ignoreNulls)
                {
                    return JsonConvert.SerializeObject(model, Formatting.None,
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                        });
                }
                return JsonConvert.SerializeObject(model);
            }
            catch (Exception e)
            {
                Log.Info(e.Message);
                return "Unable to get json from object model";
            }
        }
        public static bool IsValidJson(string stringInput)
        {
            stringInput = stringInput.Trim();
            if (stringInput.StartsWith("{") && stringInput.EndsWith("}") ||
                stringInput.StartsWith("[") && stringInput.EndsWith("]"))
            {
                try
                {
                    var jToken = JToken.Parse(stringInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            {
                return false;
            }
        }
    }
}
