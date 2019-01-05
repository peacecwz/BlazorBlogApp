using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace BlogApp.Web.Extensions
{
    public static class HttpClientExtensions
    {
        public static string WithQueryParams(this string url, object obj)
        {
            var properties = obj.GetType().GetProperties()
                .Where(x => x.GetValue(obj, null) != null)
                .Select(x => x.Name + "=" + HttpUtility.UrlEncode(x.GetValue(obj, null).ToString()));

            return $"{url}?" + String.Join("&", properties.ToArray());
        }

        public static async Task<T> ReadAs<T>(this HttpContent content) where T : class
        {
            try
            {
                var json = await content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}