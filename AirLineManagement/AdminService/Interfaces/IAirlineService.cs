using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Interfaces
{
    public interface IAirlineService
    {
        bool AddAirline(Airline airline);
    }
}
