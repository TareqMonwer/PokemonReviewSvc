using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper) { 
            this._repository = pokemonRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Pokemon>> Get()
        {
            var pokemon = this._mapper.Map<IEnumerable<PokemonDto>>(this._repository.GetPokemons());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pokemon> GetPokemon(int id)
        {
            if (!_repository.PokemonExists(id))
            {
                return NotFound();
            }

            var pokemon = this._mapper.Map<PokemonDto>(_repository.GetPokemon(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemon);
        }

        [HttpGet("search/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pokemon> GetPokemon(string name)
        {
            var pokemon = this._mapper.Map<PokemonDto>(_repository.GetPokemon(name));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpGet("{id}/rating")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public ActionResult<Pokemon> GetPokemonRating(int id)
        {
            if (!_repository.PokemonExists(id))
            {
                return NotFound();
            }

            var rating = _repository.GetPokemonRating(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok(rating);
        }
    }
}
