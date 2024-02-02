using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommandConsole
{
    internal class JokeResponse
    {
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public int Id { get; set; }
    }

    internal class CommandJoke : ICommand
    {
        private readonly HttpClient client;

        public CommandJoke()
        {
            client = new HttpClient();
        }

        public string Name => "joke";

        public string HelpText => "joke[-ten] -> Get a random joke, or optionally ten random jokes.";

        public async void Execute(string parameter)
        {
            string apiUrl = "https://official-joke-api.appspot.com/random_joke";
            if (parameter == "ten")
            {
                apiUrl = "https://official-joke-api.appspot.com/jokes/ten";
            }

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JokeResponse joke = JsonSerializer.Deserialize<JokeResponse>(result);

                    Console.WriteLine($"Joke ID: {joke.Id}");
                    Console.WriteLine($"Type: {joke.Type}");
                    Console.WriteLine($"Setup: {joke.Setup}");
                    Console.WriteLine($"Punchline: {joke.Punchline}");
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get joke from API: {ex.Message}");
            }
        }
    }
}
