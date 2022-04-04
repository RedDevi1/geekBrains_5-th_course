using System;
using System.Net.Http;
using System.Text.Json;

namespace Lesson_1
{
    class Program
    {
        private readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {             
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"/posts/{id}");
            try
            {
                HttpResponseMessage response = client.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;

                var metricsResponse = JsonSerializer.DeserializeAsync<AllHddMetricsApiResponse>(responseStream).Result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
