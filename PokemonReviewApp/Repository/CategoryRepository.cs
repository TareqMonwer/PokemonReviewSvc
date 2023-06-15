using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context) {
            this._context = context;
        }
        public bool CategoriesExists(int id)
        {
            return this._context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return this._context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return this._context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int categoryId)
        {
            var pokemon = this._context.PokemonCategories.Where(e => e.CategoryId == categoryId)
                .Select(pc => pc.Pokemon)
                .ToList();
            return pokemon;
        }
    }
}
