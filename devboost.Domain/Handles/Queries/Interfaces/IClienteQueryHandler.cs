using devboost.Domain.Commands.Request;
using devboost.Domain.Model;
using devboost.Domain.Queries.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries.Interfaces
{
    public interface IClienteQueryHandler
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> CriarCliente(CriarClienteRequest pedido);
        Task<List<Cliente>> GetAllPedido();
    }
}
