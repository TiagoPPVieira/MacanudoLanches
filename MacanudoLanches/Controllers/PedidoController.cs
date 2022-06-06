using MacanudoLanches.Models;
using MacanudoLanches.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MacanudoLanches.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedido = 0;
            decimal precoTotalPedido = 0.0m;

            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItem();
            _carrinhoCompra.CarrinhoCompraItems = items;

            if(_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState
                    .AddModelError("", "Seu carrinho está vazio. Que tal incluir um lanche?");
            }

            foreach(var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Lanche.Price * item.Quantidade);
            }
            pedido.TotalItensPedido = totalItensPedido;
            pedido.PedidoTotal = precoTotalPedido;
            if (ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();
                _carrinhoCompra.LimparCarrinho();
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }
            return View(pedido);
        }
    }
}
