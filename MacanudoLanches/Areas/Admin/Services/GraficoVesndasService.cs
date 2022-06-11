using MacanudoLanches.Context;
using MacanudoLanches.Models;
using System.Linq;

namespace MacanudoLanches.Areas.Admin.Services
{
    public class GraficoVesndasService
    {
        private readonly AppDbContext _context;

        public GraficoVesndasService(AppDbContext context)
        {
            _context = context;
        }
        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanches = (from pd in _context.PedidoDetalhe
                           join l in _context.Lanches on pd.LancheId equals l.Id
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Name, pd.Quantidade }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Name,
                               LanchesQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });
            var lista = new List<LancheGrafico>();

            foreach (var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
                lista.Add(lanche);
            }

            return lista;
        }
    }
}
