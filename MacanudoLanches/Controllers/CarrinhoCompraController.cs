using MacanudoLanches.Models;
using MacanudoLanches.Repositories.Interfaces;
using MacanudoLanches.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MacanudoLanches.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItem();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(
                p => p.Id == lancheId);
            if(lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);  
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(
                p => p.Id == lancheId);
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
