using Microsoft.AspNetCore.Mvc;
using MacanudoLanches.Repositories.Interfaces;
using MacanudoLanches.Repositories;
using MacanudoLanches.ViewModels;

namespace MacanudoLanches.Controllers
{
    public class LancheController : Controller
{
        private readonly ILancheRepository _lancheRepository;
        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            /*ViewData["Titulo"] = "Todos os Lanches";
            ViewData["Data"] = DateTime.Now;

            var lanches = _lancheRepository.Lanches;
            var totalLanches = lanches.Count();

            ViewBag.Total = "Total de lanches: ";
            ViewBag.TotalLanches = totalLanches;

            return View(lanches);*/
            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CurrentCategory = "Categoria atual";

            return View(lanchesListViewModel);
        }
    }
}
