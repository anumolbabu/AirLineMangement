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
    public class FlightRepository : IFlightRepository
    {
        private readonly AirLineDBContext _airLineDBContext;
        public FlightRepository(AirLineDBContext airLineDBContext)
        {
            _airLineDBContext = airLineDBContext;
        }
        public async Task<bool> Create(Flight flight)
        {
            _airLineDBContext.Flights.Add(flight);
            int success = await _airLineDBContext.SaveChangesAsync();
            if (success == 0)
            {
                return true;
            }
            return true;
        }

        public async Task<bool> Edit(Flight flight)
        {
            _airLineDBContext.Flights.Update(flight);
            int success = await _airLineDBContext.SaveChangesAsync();
            if (success == 0)
            {
                return true;
            }
            return true;
        }

        public async Task<bool> Delete(int FlightId)
        {

            var flight = await _airLineDBContext.Flights.Where(x => x.FlightId == FlightId).FirstOrDefaultAsync();
            _airLineDBContext.Flights.Remove(flight);
            int success = await _airLineDBContext.SaveChangesAsync();
            if (success == 0)
            {
                return true;
            }
            return true;
        }

        public async Task<IEnumerable<Flight>> GetAll()
        {
            return await _airLineDBContext.Flights.ToListAsync();
        }

        public async Task<Flight> GetById(int FlightId)
        {
            return await _airLineDBContext.Flights.FindAsync(FlightId);
        }

        public async Task<dynamic> SearchFlight(Schedule schedule)
        {
            //tables: Airline, Flight, Schedule
            //Airline name
            //flightnumber
            //from
            //to
            //start 
            //end time
            //price
            //List<dynamic> result =
            var scheduledata = _airLineDBContext.Schedules.Where(x => x.FromPlace == schedule.FromPlace &&
                                                                         x.ToPlace == schedule.ToPlace &&
                                                                         x.StartDateTime == schedule.StartDateTime &&
                                                                         x.EndDateTime == schedule.EndDateTime).ToList();
                                                               
            //var flightdata=_airLineDBContext.Schedules.Join(
            //                                                _airLineDBContext.Flights, 
            //                                                schedules=>schedules.ScheduleId,
            //                                                flights=>flights.FlightId,
            //                                                (schedules,flights)=>new { schedules, flights }
            //                                                )
            //                                           .Join(_airLineDBContext.Airlines
            //                                                )






            return await _airLineDBContext.Flights.FindAsync();
        }
    }
}
