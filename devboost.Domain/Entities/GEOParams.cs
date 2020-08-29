namespace devboost.Domain.Entities
{
    public class GEOParams
    {
        public GEOParams(double latitudeOrigem, double longitudeOrigem, double latitudeDestino, double longitudeDestino)
        {
            LatitudeOrigem = latitudeOrigem;
            LongitudeOrigem = longitudeOrigem;
            LatitudeDestino = latitudeDestino;
            LongitudeDestino = longitudeDestino;
        }

        public double LatitudeOrigem { get; private set; }
        public double LongitudeOrigem { get; private set; }
        public double LatitudeDestino { get; private set; }
        public double LongitudeDestino { get; private set; }
    }
}
