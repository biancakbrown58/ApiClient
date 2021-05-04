using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiClient
{
    class Item
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("setup")]
        public string Setup { get; set; }
        [JsonPropertyName("punchline")]
        public string Punchline { get; set; }
    }

    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new HttpClient();
            var url = $"https://official-joke-api.appspot.com/jokes/programming/random";
            var responseAsStream = await client.GetStreamAsync(url);

            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseAsStream);

            foreach (var item in items)
            {
                Console.WriteLine($"Want to hear a joke? {item.Setup}");
                Console.WriteLine($"{item.Punchline}");
            }
        }
    }
}

// [
//   {
//     "id": 33,
//     "type": "programming",
//     "setup": "Which song would an exception sing?",
//     "punchline": "Can't catch me - Avicii"
//   }
// ]