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
        AirlineDBContext _airlineDBContext;
        public AirlineRepository(AirlineDBContext airlineDBContext)
        {
        _airlineDBContext= airlineDBContext;
        }

        /// <summary>
        /// Add AirLine
        /// </summary>
        /// <param name="airline">airline</param>
        /// <returns></returns>
        public Airline Create(Airline airline)
        {
            //Airline airline1 = new Airline();
            airline.IsBlocked = 0;
            airline.CreatedBy = "User";
            airline.CreatedDate = System.DateTime.UtcNow;
            airline.UpdatedBy = "User";
            airline.UpdatedDate = System.DateTime.UtcNow;

            //airline.
            _airlineDBContext.Airlines.Add(airline);
            int success= _airlineDBContext.SaveChanges();
            if (success == 0)
            {
                throw new Exception("Failed to add airline data");
            }
            var currentairline = _airlineDBContext.Airlines.Where(x => x.AirlineName == airline.AirlineName && x.ContactNumber==airline.ContactNumber).FirstOrDefault();
            return currentairline;
        }

        public Airline Edit(Airline airline)
        {
            airline.UpdatedBy = "User";
            airline.UpdatedDate = System.DateTime.UtcNow;
            _airlineDBContext.Airlines.Update(airline);
            int success = _airlineDBContext.SaveChanges();
            if (success == 0)
            {
                throw new Exception("Failed to update airline data");
            }
            var currentairline = _airlineDBContext.Airlines.Where(x => x.AirlineId == airline.AirlineId).FirstOrDefault();
            return currentairline;
        }

        /// <summary>
        /// Delete Airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public bool Delete(int airlineId)
        {
            var airline = _airlineDBContext.Airlines.Where(x => x.AirlineId == airlineId).FirstOrDefault();
            _airlineDBContext.Airlines.Remove(airline);
            int success = _airlineDBContext.SaveChanges();
            if (success == 0)
            {
                return true;
            }
            return true;
        }

       

        public Airline GetById(int airlineId)
        {
            return _airlineDBContext.Airlines.Find(airlineId);
        }

        public IEnumerable<Airline> GetAll()
        {
            return _airlineDBContext.Airlines.ToList();
        }
    }
}
