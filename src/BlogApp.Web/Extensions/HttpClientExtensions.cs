using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.JSInterop;

namespace BlogApp.Web.Extensions
{
    public static class HttpClientExtensions
    {
        public static string WithQueryParams(this string endpoint, object value)
        {
            if (value == null)
            {
                return endpoint;
            }

            try
            {

                var parameters = value.GetType().GetProperties()
                    .Where(prop => prop.GetValue(value) != null)
                    .Select(prop => $"{prop.Name}={prop.GetValue(value)?.ToString()}")
                    .ToList();

                return $"{endpoint}?" + string.Join("&", parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Get exception on WithQueryParams, Exception: {ex.Message}");
            }

            return endpoint;
        }

        public static async Task<T> ReadAs<T>(this HttpContent content)
        {
            try
            {
                if (content == null)
                {
                    return default(T);
                }
                var json = await content.ReadAsStringAsync();
                return Json.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Get exception on ReadAs, Exception: {ex.Message}");
            }

            return default(T);
        }
    }
}