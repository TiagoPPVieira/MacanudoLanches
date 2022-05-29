using MacanudoLanches.Models;

namespace MacanudoLanches.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
