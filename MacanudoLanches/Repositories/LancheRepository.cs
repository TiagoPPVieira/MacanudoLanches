using MacanudoLanches.Context;
using MacanudoLanches.Models;
using MacanudoLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MacanudoLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _appDbContext;

        public LancheRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public IEnumerable<Lanche> Lanches => _appDbContext.Lanches.Include(c => c.Category);

        public IEnumerable<Lanche> LanchesPreferidos => _appDbContext.Lanches
            .Where(l => l.IsLanchePreferred)
            .Include(c => c.Category);

        public Lanche GetLancheById(int lancheId)
        {
            return _appDbContext.Lanches.FirstOrDefault(l => l.Id == lancheId);
        }
    }
}
