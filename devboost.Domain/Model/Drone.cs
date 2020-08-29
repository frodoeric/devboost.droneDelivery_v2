using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace devboost.Domain.Model
{
    public class Drone
    {
        public int Id { get; set; }
        public int Capacidade { get; set; }
        public int Velocidade { get; set; }
        public int Autonomia { get; set; }
        public int Carga { get; set; }
        public StatusDrone StatusDrone { get; set; }

        [NotMapped]
        public string DescricaoStatus
        {
            get
            {
                switch (StatusDrone)
                {
                    case StatusDrone.indisponivel:
                        return "Indisponível";
                    case StatusDrone.disponivel:
                        return "Disponível";
                    case StatusDrone.emTrajeto:
                        return "Em trajeto";
                    default:
                        return string.Empty;
                }
            }
        }

        public List<PedidoDrone> PedidosDrones { get; set; } = new List<PedidoDrone>();

        [NotMapped]
        public double AutonomiaEmKM
        {
            get
            {
                //Calcular Distância que o Drone pode percorrer
                //Primeiro: Calcular a Autonomia restante = AM = Automonima em Minutos *Carga / 100
                var autonomiaEmMinutos = (double)((Autonomia * Carga) / 100);
                //Segundo: Transformar a Autonomia encontrada em minutos para horas = AH = AM / 60
                var autonomiaEmHoras = autonomiaEmMinutos / 60;
                //Terceiro: Calcular a distância que o Drone pode percorrer = AH * Velocidade (KM/H)
                return Velocidade * autonomiaEmHoras;
            }
        }
    }

    public enum StatusDrone
    {
        indisponivel = 0,
        disponivel = 1,
        emTrajeto = 2
    }
}
