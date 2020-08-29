using GeoLocation;

namespace devboost.Domain.Entities
{
    public static class GEOCalculaDistancia
    {
        public static double CalculaDistanciaEmKM(GEOParams geoParams)
        {
            return new Coordinates(geoParams.LatitudeOrigem, geoParams.LongitudeOrigem)
                .DistanceTo(
                    new Coordinates(geoParams.LatitudeDestino, geoParams.LongitudeDestino),
                    UnitOfLength.Kilometers
                );
        }
    }
}
