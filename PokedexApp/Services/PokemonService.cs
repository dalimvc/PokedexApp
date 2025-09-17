using Microsoft.Net.Http.Headers;
using PokedexApp.Models;
using System.Text.Json;

//documentation for this:
//Make HTTP requests using IHttpClientFactory in ASP.NET Core
//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-9.0

namespace PokedexApp.Services
{
    //Pokemon service is  a service that Controller will use to get data about Pokemons
    public class PokemonService
    {
        //to use IHttpClientFactory to create HTTP client
        private readonly IHttpClientFactory _httpClientFactory;

        //it is passed as injection
        public PokemonService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        //a method that takes an input and if found it returns a Pokemon
        //if not returns null
        //it sends request and gets the answer back based on the input
        public async Task<Pokemon?> GetPokemon(string input)
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://pokeapi.co/api/v2/pokemon/{input}")
            {
                Headers =
            {
                { HeaderNames.Accept, "application/json" },
                { HeaderNames.UserAgent, "HttpRequestsSample" }
            }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return null;
            }
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            using var jsonDocument = JsonDocument.Parse(contentStream);
            var root = jsonDocument.RootElement;

            return new Pokemon
            {
                id = root.GetProperty("id").GetInt32(),
                name = root.GetProperty("name").GetString()!,
                image = root.GetProperty("sprites").GetProperty("front_default").GetString()!
            };
        }



    }
}