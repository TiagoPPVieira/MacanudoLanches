using Microsoft.AspNetCore.Mvc;
using MacanudoLanches.Repositories.Interfaces;
using MacanudoLanches.Repositories;
using MacanudoLanches.ViewModels;
using MacanudoLanches.Models;

namespace MacanudoLanches.Controllers
{
    public class LancheController : Controller
{
        private readonly ILancheRepository _lancheRepository;
        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                lanches = _lancheRepository.Lanches
                    .OrderBy(l => l.Name).ToList();
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                /*if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Category.Name.Equals("Normal"))
                        .OrderBy(l => l.Name);
                }
                else if(string.Equals("Natural", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Category.Name.Equals("Natural"))
                        .OrderBy(l => l.Name);
                }
                //Lógica para não deixar criar titulos inexistentes
                else
                {
                    throw new Exception("404");
                }*/
                lanches = _lancheRepository.Lanches
                            .Where(l => l.Category.Name.Equals(category))
                            .OrderBy(c => c.Name);
                categoriaAtual = category;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CurrentCategory = categoriaAtual
            };

            return View(lanchesListViewModel);
        }
        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches
                .FirstOrDefault(c => c.Id == lancheId);
            return View(lanche);
        }
    }
}
