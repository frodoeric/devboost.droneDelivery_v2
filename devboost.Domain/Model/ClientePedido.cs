using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.Domain.Model
{
    public class ClientePedido
    {
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
