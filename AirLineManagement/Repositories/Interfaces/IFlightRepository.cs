using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    /// <summary>
    ///  interface IFlightRepository
    /// </summary>
    public interface IFlightRepository
    {
        /// <summary>
        /// Create new Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns>Status of creation</returns>
        bool Create(Flight flight);

        /// <summary>
        /// Delete existing Flight
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        bool Delete(int FlightId);

        /// <summary>
        /// Update existing Flight
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        bool Edit(int FlightId);

        /// <summary>
        /// Get single Flight by Id
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        Airline GetById(int FlightId);

        /// <summary>
        /// Get All Flight
        /// </summary>
        /// <returns></returns>
        IEnumerable<Airline> GetAll();
    }
}
