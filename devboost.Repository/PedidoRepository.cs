using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        readonly DataContext _dataContext;

        public PedidoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Pedido>> GetPedidos(StatusPedido statusPedido)
        {
            return await _dataContext.Pedido
                .Where(x => (int)x.StatusPedido == (int)statusPedido)
                .ToListAsync();
        }

        public async Task<List<Pedido>> GetPedidos(StatusPedido statusPedido, double distancia, int peso)
        {
            return await _dataContext.Pedido
                .Where(x => (int)x.StatusPedido == (int)statusPedido && x.DistanciaParaOrigem <= distancia && x.Peso <= peso)
                .OrderBy(x => x.DistanciaParaOrigem)
                .ToListAsync();
        }

        public async Task AddPedido(Pedido pedido)
        {
            _dataContext.Pedido.Add(pedido);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdatePedido(Pedido pedido)
        {
            _dataContext.Pedido.Update(pedido);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddPedidoDrone(PedidoDrone pedidoDrone)
        {
            _dataContext.PedidoDrone.Add(pedidoDrone);
            await _dataContext.SaveChangesAsync();
        }
    }
}
