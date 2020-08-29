using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devboost.Domain.Commands.Request;
using devboost.Domain.Handles.Queries.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IClienteQueryHandler _clienteHandler;

        public ClienteController(IClienteQueryHandler clienteHandler)
        {
            _clienteHandler = clienteHandler;
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Get()
        {
            var result = await _clienteHandler.GetAll();
            return Ok(result);
        }

        [HttpGet("TodoscomPedido")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> GetAllPedidos()
        {
            var result = await _clienteHandler.GetAllPedido();
            return Ok(result);
        }

        [HttpPost("criarCliente")]
        [Authorize(Roles = "admin,usuario")]
        public async Task<ActionResult> RealizarPedido([FromBody] CriarClienteRequest cliente)
        {
            var result = await _clienteHandler.CriarCliente(cliente);
            return Ok(result);
        }

    }
}
