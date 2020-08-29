using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Queries.Filters;
using devboost.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries
{
    public class ClienteQueryHandler : IClienteQueryHandler
    {
        readonly IClienteRepository _clienteRepository;
        readonly IUserRepository userRepository;

        public ClienteQueryHandler(IClienteRepository clienteRepository, IUserRepository userRepository)
        {
            _clienteRepository = clienteRepository;
            this.userRepository = userRepository;
        }

        public async Task<Cliente> CriarCliente(CriarClienteRequest clienteRequest)
        {
            var user = await this.userRepository.GetUser(clienteRequest.UserName);
            if (user == null)
                throw new Exception("Não foi possível encontrar o usuário autenticado.");
            var cliente = new Cliente(clienteRequest.Latitude, clienteRequest.Longitude)
            {
                User = user,
                UserId = user.Id
            };
            if (!cliente.IsValid())
                throw new Exception("Dados do cliente inválido");
            return await _clienteRepository.Create(cliente);
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<List<Cliente>> GetAllPedido()
        {
            return await _clienteRepository.GetAllPedidos();
        }

    }
}
