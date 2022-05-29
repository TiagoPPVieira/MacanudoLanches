using MacanudoLanches.Context;
using MacanudoLanches.Models;
using MacanudoLanches.Repositories.Interfaces;

namespace MacanudoLanches.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.categories;
    }
}
