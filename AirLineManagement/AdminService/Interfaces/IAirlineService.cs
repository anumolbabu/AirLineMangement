using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Interfaces
{
    public interface IAirlineService
    {
        /// <summary>
        /// Create new Airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        Task<bool> Create(Airline airline);

        /// <summary>
        /// Delete existing Airline
        /// </summary>
        /// <param name="airlineId"></param>
        /// <returns></returns>
        Task<bool> Delete(int airlineId);

        /// <summary>
        /// Update existing Airline
        /// </summary>
        /// <param name="airlineId"></param>
        /// <returns></returns>
        Task<bool> Edit(Airline airline);

        /// <summary>
        /// Get single Airline by Id
        /// </summary>
        /// <param name="airlineId"></param>
        /// <returns></returns>
        Task<Airline> GetById(int airlineId);

        /// <summary>
        /// Get All Airlines
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Airline>> GetAll();
    }
}
