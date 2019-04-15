using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PoopBuddy.Shared.Http
{
    public static class HttpClientHelper
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        static HttpClientHelper()
        {
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.Timeout = TimeSpan.FromSeconds(10); // we don't want to wait any longer
        }

        public static async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, string address)
        {
            var serializedRequest = JsonSerializerHelper.Serialize(request);
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new StringContent(serializedRequest, Encoding.UTF8, "application/json"),
                RequestUri = new Uri(address)
            };

            return await SendInternal<TResponse>(httpRequest);
        }

        public static async Task<TResponse> GetAsync<TResponse>(string address)
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(address)
            };

            return await SendInternal<TResponse>(httpRequest);
        }

        private static async Task<TResponse> SendInternal<TResponse>(HttpRequestMessage request)
        {
            var response = await HttpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseStringContent = await response.Content.ReadAsStringAsync();

            return JsonSerializerHelper.Deserialize<TResponse>(responseStringContent);
        }
    }
}
