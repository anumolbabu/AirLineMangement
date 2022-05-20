using AdminService.Interfaces;
using CoreModels.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Services
{
    public class FlightService : IFlightServices
    {

        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        /// <summary>
        /// Add new flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public async Task<bool> Create(Flight flight)
        {
            return await _flightRepository.Create(flight);
        }

        /// <summary>
        /// Delete flight
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int FlightId)
        {
            return await _flightRepository.Delete(FlightId);
        }


        /// <summary>
        /// Edit flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public async Task<bool> Edit(Flight flight)
        {
            return await _flightRepository.Edit(flight);
        }

        public async Task<IEnumerable<Flight>> GetAll()
        {
            return await _flightRepository.GetAll();
        }

        public async Task<Flight> GetById(int FlightId)
        {
            return await _flightRepository.GetById(FlightId);

        }
    }
}
