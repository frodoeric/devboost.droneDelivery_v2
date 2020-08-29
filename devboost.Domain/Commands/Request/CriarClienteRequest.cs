using devboost.Domain.Model;

namespace devboost.Domain.Commands.Request
{
    public class CriarClienteRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string UserName { get; set; }
    }
}
