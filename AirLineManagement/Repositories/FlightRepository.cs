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
        private readonly AirlineDBContext _airlineDBContext;
        public FlightRepository(AirlineDBContext airlineDBContext)
        {
            _airlineDBContext = airlineDBContext;
        }
        public Flight Create(Flight flight)
        {
            flight.RemainingBc = flight.BusinessClassSeats;
            flight.RemainingNonBc = flight.NonBusinessClassSeats;

            flight.CreatedBy = "User";
            flight.CreatedDate = System.DateTime.UtcNow;
            flight.UpdatedBy = "User";
            flight.UpdatedDate = System.DateTime.UtcNow;

            _airlineDBContext.Flights.Add(flight);
            int success =  _airlineDBContext.SaveChanges();
            if (success == 0)
            {
                throw new Exception("Failed to Edit Inventory");
            }
            var currentflight = _airlineDBContext.Flights.Where(x => x.FlightNumber == flight.FlightNumber).FirstOrDefault();

            return currentflight;
        }

        public Flight Edit(Flight flight)
        {
            flight.UpdatedBy = "User";
            flight.UpdatedDate = System.DateTime.UtcNow;

            _airlineDBContext.Flights.Update(flight);
            int success =  _airlineDBContext.SaveChanges();
            if (success == 0)
            {
                throw new Exception("Failed to Edit Inventory");
            }
            var currentflight = _airlineDBContext.Flights.Where(x => x.FlightNumber == flight.FlightNumber).FirstOrDefault();

            return currentflight;
        }

        public bool Delete(int FlightId)
        {
            var flight =  _airlineDBContext.Flights.Where(x => x.FlightId == FlightId).FirstOrDefault();
            _airlineDBContext.Flights.Remove(flight);
            int success =  _airlineDBContext.SaveChanges();
            if (success == 0)
            {
                return true;
            }
            return true;
        }

        public IEnumerable<Flight> GetAll()
        {
            return _airlineDBContext.Flights.ToList();
        }

        public Flight GetById(int FlightId)
        {
            return _airlineDBContext.Flights.Find(FlightId);
        }

        public dynamic SearchFlight(Flight flight)
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



            //var scheduledata = _airlineDBContext.Flights.Where(x => x.FromPlace == flight.FromPlace &&
            //                                                            x.ToPlace == flight.ToPlace &&
            //                                                            x.StartDateTime == flight.StartDateTime &&
            //                                                            x.EndDateTime == flight.EndDateTime).ToList();



            var flights= _airlineDBContext.Flights.Join(
                                                            _airlineDBContext.Airlines,
                                                            flights => flights.AirlineId,
                                                            airlines => airlines.AirlineId,
                                                            (flights, airlines) => new { flights, airlines }
                                                            )
                                                      .Where(x => x.flights.FromPlace == flight.FromPlace &&
                                                                        x.flights.ToPlace == flight.ToPlace &&
                                                                        x.flights.StartDateTime == flight.StartDateTime &&
                                                                        x.flights.EndDateTime == flight.EndDateTime &&
                                                                        x.airlines.IsBlocked==0)
                                                      .Select(x=>x.airlines.AirlineId);






            return flights;
        }
    }
}
