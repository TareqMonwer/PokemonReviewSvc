using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _repository;

        public PokemonController(IPokemonRepository pokemonRepository) { 
            this._repository = pokemonRepository;
        }

        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            return this._repository.GetPokemons();
        }
    }
}
