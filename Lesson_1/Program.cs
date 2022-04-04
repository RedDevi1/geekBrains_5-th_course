using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        static readonly HttpClient client = new();
        static async Task Main(string[] args)
        {
            for (var i = 4; i <= 13; i++)
            {
                await GetPostById(i);
            }
        }

        static async Task GetPostById (int id)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var responseBodyArray = responseBody.TrimStart('{').TrimEnd('}').Split(',');
                File.AppendAllLines("result.txt", responseBodyArray);
                File.AppendAllText("result.txt", "\r");

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
