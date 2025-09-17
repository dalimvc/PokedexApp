using Microsoft.AspNetCore.Mvc;
using PokedexApp.Models;
using PokedexApp.Services;
using System.Runtime.CompilerServices;



namespace PokedexApp.Controllers
{
    [ApiController] //for automatic validation
    [Route("[controller]")] //used for ading endpoints
    //defining controller
    public class PokemonController : Controller
    {
        //for dependency injection
        private readonly PokemonService _pokemonService;

        //dependency injection
        //it takes in pokemonService from PokemonService so that controller can use it
        public PokemonController (PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        //gets data about pokemon based on the input
        //IActionResultis(inbuilt interface) is used to return different codes, such as 404, using regular method would not work
        [HttpGet("{input}")]
        public async Task<IActionResult> GetPokemon(string input)
        {
            var result = await _pokemonService.GetPokemon(input);
            if (result == null) return NotFound();
            return Ok(result);
        }




    }
}
