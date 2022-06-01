using MacanudoLanches.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MacanudoLanches.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoriaMenu(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categorias = _CategoryRepository.Categories
                .OrderBy(c => c.Name);
            return View(categorias);
        }
    }
}
