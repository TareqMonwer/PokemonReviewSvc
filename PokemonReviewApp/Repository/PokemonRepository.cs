using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System.Xml.Linq;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context) { 
            this._context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name.Contains(name)).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id)
        {
            var reviews = _context.Reivews.Where(r => r.Pokemon.Id == id);
            if (reviews.Count() <= 0)
                return 0;

            return ((decimal)reviews.Sum(r => r.Rating) / (decimal)reviews.Count());
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return this._context.Pokemons.ToList();
        }

        public bool PokemonExists(int id)
        {
            return this._context.Pokemons.Any(p => p.Id == id);
        }
    }
}
