﻿using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Interfaces
{
    public interface IFlightServices
    {
        /// <summary>
        /// Create new Flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns>Status of creation</returns>
        Task<bool> Create(Flight flight);

        /// <summary>
        /// Update existing Flight
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        Task<bool> Edit(Flight flight);

        /// <summary>
        /// Delete existing Flight
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        Task<bool> Delete(int FlightId);

        /// <summary>
        /// Get single Flight by Id
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        Task<Flight> GetById(int FlightId);

        /// <summary>
        /// Get All Flight
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Flight>> GetAll();
    }
}
