using System;

namespace devboost.Domain.Model
{
    public class PedidoDrone
    {
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int DroneId { get; set; }
        public Drone Drone { get; set; }
    }
}
