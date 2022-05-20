using CoreModels.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AirlineRepository : IAirlineRepository
    {
        AirLineDBContext _airLineDBContext;
        public AirlineRepository(AirLineDBContext airLineDBContext)
        {
        _airLineDBContext=airLineDBContext;
        }

        /// <summary>
        /// Add AirLine
        /// </summary>
        /// <param name="airline">airline</param>
        /// <returns></returns>
        public async Task<bool> Create(Airline airline)
        {
            _airLineDBContext.Airlines.Add(airline);
            int success=await _airLineDBContext.SaveChangesAsync();
            if(success==0)
            {
                return true;
            }
            return true;
        }

        public async Task<bool> Edit(Airline airline)
        {
            _airLineDBContext.Airlines.Update(airline);
            int success = await _airLineDBContext.SaveChangesAsync();
            if (success == 0)
            {
                return true;
            }
            return true;
        }

        /// <summary>
        /// Delete Airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int airlineId)
        {
            var airline = await _airLineDBContext.Airlines.Where(x => x.AirlineId == airlineId).FirstOrDefaultAsync();
            _airLineDBContext.Airlines.Remove(airline);
            int success = await _airLineDBContext.SaveChangesAsync();
            if (success == 0)
            {
                return true;
            }
            return true;
        }

       

        public async Task<Airline> GetById(int airlineId)
        {
            return await _airLineDBContext.Airlines.FindAsync(airlineId);
        }

        public async Task<IEnumerable<Airline>> GetAll()
        {
            return await _airLineDBContext.Airlines.ToListAsync();
        }
    }
}
