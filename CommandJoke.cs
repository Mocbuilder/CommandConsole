﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommandConsole
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

        public string HelpText => "joke[-ten] -> Get a random joke, or optionally ten random jokes.";

        public async void Execute(string parameter)
        {
            string apiUrl = "https://official-joke-api.appspot.com/random_joke";
            if (parameter == "ten")
            {
                apiUrl = "https://official-joke-api.appspot.com/jokes/ten";

                try
                {
                    HttpResponseMessage tenresponse = await client.GetAsync(apiUrl);

                    if (tenresponse.IsSuccessStatusCode)
                    {
                        string result = await tenresponse.Content.ReadAsStringAsync();
                        for (int i = 0; i < 10; i++)
                        {
                            JokeResponse joke = JsonSerializer.Deserialize<JokeResponse>(result);

                            Console.WriteLine($"Joke ID: {joke.id}");
                            Console.WriteLine($"Type: {joke.type}");
                            Console.WriteLine($"Setup: {joke.setup}");
                            Console.WriteLine($"Punchline: {joke.punchline}");
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
