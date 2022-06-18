using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministrationService.Interfaces
{
    /// <summary>
    /// interface IInventoryService
    /// </summary>
    public interface IInventoryService
    {
        /// <summary>
        /// Create new Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        Flight Create(Flight flight);

        /// <summary>
        /// Delete existing Flight
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        bool Delete(int flightId);

        /// <summary>
        /// Update existing Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        Flight Edit(Flight flight);

        /// <summary>
        /// Get single Flight by Id
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        Flight GetById(int flightId);

        /// <summary>
        /// Get All Flights
        /// </summary>
        /// <returns></returns>
        IEnumerable<Flight> GetAll();
    }
}
