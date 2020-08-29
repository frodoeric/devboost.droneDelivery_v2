using System;

namespace GeoLocation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------- Calcular distância entre duas corrdenadas----------------------------------------------------");

            var distance = new Coordinates(23.4765599, 46.6350522)
                .DistanceTo(
                    new Coordinates(23.4773517, 46.6320323),
                    UnitOfLength.Kilometers
                );

            Console.WriteLine(distance);
        }
    }
}
