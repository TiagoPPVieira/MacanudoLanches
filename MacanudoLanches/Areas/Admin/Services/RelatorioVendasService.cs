﻿using MacanudoLanches.Context;
using MacanudoLanches.Models;
using Microsoft.EntityFrameworkCore;

namespace MacanudoLanches.Areas.Admin.Services
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext _context;

        public RelatorioVendasService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Pedido select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }
            return await resultado.Include(l => l.PedidoItens)
                                  .ThenInclude(l => l.Lanche)
                                  .OrderByDescending(x => x.PedidoEnviado)
                                  .ToListAsync();
        }
    }
}
