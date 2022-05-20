using AdminService.Interfaces;
using CoreModels.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Services
{
    public class AirlineService: IAirlineService
    {
        private readonly IAirlineRepository _airlineRepository;
        public AirlineService(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }

        public async Task<bool> Create(Airline airline)
        {
            return await _airlineRepository.Create(airline);
        }

        public async Task<bool> Delete(int airlineId)
        {
            return await _airlineRepository.Delete(airlineId);
        }

        public async Task<bool> Edit(Airline airline)
        {
            return await _airlineRepository.Edit(airline);
        }

        public async Task<IEnumerable<Airline>> GetAll()
        {
            return await _airlineRepository.GetAll();
        }

        public async Task<Airline> GetById(int airlineId)
        {
            return await _airlineRepository.GetById(airlineId);
        }
    }
}
