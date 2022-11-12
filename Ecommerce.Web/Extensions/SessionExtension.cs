using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Ecommerce.Web.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object obj)
        {
            string objStr = JsonConvert.SerializeObject(obj);
            session.SetString(key, objStr);
        }

        public static T GetObject<T> (this ISession session, string key) where T : class 
        {
            string objStr=session.GetString(key);
            if(!string.IsNullOrEmpty(objStr)) {
                return JsonConvert.DeserializeObject<T>(objStr);
            }
            return null;
        }
    }
}
