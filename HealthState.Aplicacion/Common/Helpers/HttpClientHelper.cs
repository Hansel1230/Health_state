using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HealthState.Application.Common.Helpers
{
    public static class HttpClientHelper
    {
        private static readonly JsonSerializerOptions serializerOptions;

        static HttpClientHelper()
        {
            serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public static async Task<T> GetJsonAsync<T>(this HttpClient httpClient, string url)
        {
            url = ParseUrl(httpClient, url);
            var response = await httpClient.GetAsync(url);
            return await HandleResponse<T>(response);
        }

        public static async Task<TOut> PostJsonAsync<TIn, TOut>(this HttpClient httpClient, string url, TIn content)
        {
            url = ParseUrl(httpClient, url);
            var response = await httpClient.PostAsJsonAsync(url, content);
            return await HandleResponse<TOut>(response);
        }

        public static async Task<TOut> PutJsonAsync<TIn, TOut>(this HttpClient httpClient, string url, TIn content)
        {
            url = ParseUrl(httpClient, url);
            var response = await httpClient.PutAsJsonAsync(url, content);
            return await HandleResponse<TOut>(response);
        }

        public static async Task<T> DeleteJsonAsync<T>(this HttpClient httpClient, string url)
        {
            url = ParseUrl(httpClient, url);
            var response = await httpClient.DeleteAsync(url);
            return await HandleResponse<T>(response);
        }

        private static async Task<TOut> HandleResponse<TOut>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(data)) throw new Exception($"{(int)response.StatusCode} {response.ReasonPhrase}");
            try
            {
                return JsonSerializer.Deserialize<TOut>(data, serializerOptions); ;
            }
            catch
            {
                throw new Exception($"{(int)response.StatusCode} {response.ReasonPhrase}");
            }
        }

        private static string ParseUrl(HttpClient httpClient, string url)
        {
            url = string.IsNullOrEmpty(httpClient.BaseAddress.ToString()) ?
                url :
                httpClient.BaseAddress.ToString().EndsWith("/") ?
                $"{httpClient.BaseAddress}{url}" :
                $"{httpClient.BaseAddress}/{url}";
            return url;
        }
    }
}
