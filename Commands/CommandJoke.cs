using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommandConsole.Commands
{
    internal class JokeResponse
    {
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
        public int id { get; set; }
    }

    internal class CommandJoke : ICommand
    {
        private readonly HttpClient client;

        public CommandJoke()
        {
            client = new HttpClient();
        }

        public string Name => "joke";

        public string HelpText => "joke [-ten] -> Get a random joke, or optionally ten random jokes.";

        public async void Execute(string Parameter, string Parameter2, string Parameter3)
        {
            string apiUrl = "https://official-joke-api.appspot.com/random_joke";
            if (Parameter == "ten")
            {
                apiUrl = "https://official-joke-api.appspot.com/jokes/ten";

                try
                {
                    HttpResponseMessage tenresponse = await client.GetAsync(apiUrl);

                    if (tenresponse.IsSuccessStatusCode)
                    {
                        string result = await tenresponse.Content.ReadAsStringAsync();
                        JokeResponse[] jokes = JsonSerializer.Deserialize<JokeResponse[]>(result);

                        foreach (var joke in jokes)
                        {
                            Console.WriteLine($"Joke ID: {joke.id}");
                            Console.WriteLine($"Type: {joke.type}");
                            Console.WriteLine($"Setup: {joke.setup}");
                            Console.WriteLine($"Punchline: {joke.punchline}");
                            Console.WriteLine();
                        }
                        return;
                    }
                    else
                    {
                        throw new Exception("API-Error: " + tenresponse.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to get jokes from API: {ex.Message}");
                }
            }

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JokeResponse joke = JsonSerializer.Deserialize<JokeResponse>(result);

                    Console.WriteLine($"Joke ID: {joke.id}");
                    Console.WriteLine($"Type: {joke.type}");
                    Console.WriteLine($"Setup: {joke.setup}");
                    Console.WriteLine($"Punchline: {joke.punchline}");
                }
                else
                {
                    throw new Exception("API-Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get joke from API: {ex.Message}");
            }
        }
    }
}
