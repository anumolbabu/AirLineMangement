using AdministrationService.Interfaces;
using CoreModels.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministrationService.Services
{
    /// <summary>
    /// class InventoryService
    /// </summary>
    public class InventoryService : IInventoryService
    {
        public readonly IFlightRepository _flightRepository;

        public InventoryService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }
        public Flight Create(Flight flight)
        {
            return _flightRepository.Create(flight);
        }

        public Flight Edit(Flight flight)
        {
           return _flightRepository.Edit(flight);
        }

        public bool Delete(int flightId)
        {
            return _flightRepository.Delete(flightId);
        }

        public IEnumerable<Flight> GetAll()
        {
            return _flightRepository.GetAll();
        }

        public Flight GetById(int flightId)
        {
            return _flightRepository.GetById(flightId);
        }
    }
}
