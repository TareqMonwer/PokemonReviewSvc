using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context) { 
            this._context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return this._context.Pokemons.ToList();
        }
    }
}
