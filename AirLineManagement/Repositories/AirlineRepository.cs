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
        public bool Create(Airline airline)
        {
            _airLineDBContext.Airlines.Add(airline);
            int success= _airLineDBContext.SaveChanges();
            if(success==0)
            {
                return true;
            }
            return true;
        }

        public bool Edit(Airline airline)
        {
            _airLineDBContext.Airlines.Update(airline);
            int success =  _airLineDBContext.SaveChanges();
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
        public bool Delete(int airlineId)
        {
            var airline =  _airLineDBContext.Airlines.Where(x => x.AirlineId == airlineId).FirstOrDefault();
            _airLineDBContext.Airlines.Remove(airline);
            int success =  _airLineDBContext.SaveChanges();
            if (success == 0)
            {
                return true;
            }
            return true;
        }

       

        public Airline GetById(int airlineId)
        {
            return _airLineDBContext.Airlines.Find(airlineId);
        }

        public IEnumerable<Airline> GetAll()
        {
            return _airLineDBContext.Airlines.ToList();
        }
    }
}
