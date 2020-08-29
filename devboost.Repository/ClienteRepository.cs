using devboost.Domain.Commands.Request;
using devboost.Domain.Model;
using devboost.Domain.Repository;
using devboost.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace devboost.Repository
{
    public class ClienteRepository: IClienteRepository
    {
        readonly DataContext _dataContext;

        public ClienteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            var clienteRetorno = await _dataContext.AddAsync(cliente);
            await _dataContext.SaveChangesAsync();

            return clienteRetorno.Entity;
        }

        public async Task<List<Cliente>> GetAll()
        {
            var clientes = await _dataContext.Cliente
                .Include(x => x.User)
                .ToListAsync();

            return clientes;
        }

        public async Task<List<Cliente>> GetAllPedidos()
        {
            var clientes = await _dataContext.Cliente
                .Include(x => x.ClientePedidos)
                .ThenInclude(x => x.Pedido)
                .ToListAsync();

            return clientes;
        }
    }
}
