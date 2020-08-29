using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Model;
using devboost.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Queries
{
    public class DroneHandler : IDroneHandler
    {
        readonly IDroneRepository _droneRepository;

        public DroneHandler(IDroneRepository droneRepository)
        {
            _droneRepository = droneRepository;
        }

        public async Task<List<Drone>> BuscarDrone()
        {
            return await _droneRepository.GetAll();
        }
    }
}
