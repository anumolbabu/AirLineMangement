using AdministrationService.Interfaces;
using CoreModels.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministrationService.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository _airlineRepository;
        public AirlineService(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }

        public Airline Create(Airline airline)
        {
            return _airlineRepository.Create(airline);
        }

        public Airline Edit(Airline airline)
        {
            return _airlineRepository.Edit(airline);
        }

        public bool Delete(int airlineId)
        {
            return _airlineRepository.Delete(airlineId);
        }

        public IEnumerable<Airline> GetAll()
        {
            return _airlineRepository.GetAll();
        }

        public Airline GetById(int airlineId)
        {
            return  _airlineRepository.GetById(airlineId);
        }
    }
}
