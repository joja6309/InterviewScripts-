using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace EmPower
{
    class Post
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            SendRequest().Wait();
            Console.ReadLine();
        }

        private static async Task SendRequest()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://wordsapiv1.p.mashape.com/words/example");
                    var response = await client.GetAsync("/posts");
                    response.EnsureSuccessStatusCode(); // Throw in not success

                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(stringResponse);

                    Console.WriteLine($"Got {posts.Count()} posts");
                    Console.WriteLine($"First post is {JsonConvert.SerializeObject(posts.First())}");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}
