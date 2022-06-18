using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAirlineRepository
    {
        /// <summary>
        /// Create new Airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        Airline Create(Airline airline);

        /// <summary>
        /// Delete existing Airline
        /// </summary>
        /// <param name="airlineId"></param>
        /// <returns></returns>
        bool Delete(int airlineId);

        /// <summary>
        /// Update existing Airline
        /// </summary>
        /// <param name="airlineId"></param>
        /// <returns></returns>
        Airline Edit(Airline airline);

        /// <summary>
        /// Get single Airline by Id
        /// </summary>
        /// <param name="airlineId"></param>
        /// <returns></returns>
        Airline  GetById(int airlineId);

        /// <summary>
        /// Get All Airlines
        /// </summary>
        /// <returns></returns>
        IEnumerable<Airline>  GetAll();

    }
}
