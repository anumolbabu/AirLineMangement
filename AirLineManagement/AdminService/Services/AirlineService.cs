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
        IAirlineRepository _airlineRepository;
        public AirlineService(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }
        public bool AddAirline(Airline airline)
        {
            return _airlineRepository.Create(airline);
        }
    }
}
