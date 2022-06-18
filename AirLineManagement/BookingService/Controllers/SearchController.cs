using CoreModels.Models;
using BookingService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Controllers
{
    [Route("api/v1.0/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly AirlineDBContext _airlineDBContext;
        public SearchController(AirlineDBContext airlineDBContext)
        {
            _airlineDBContext = airlineDBContext;
        }

        [HttpPost]
        [Route("getflights")]
        public IActionResult Search(SearchRequestModel searchRequest)
        {
            IEnumerable<Flight> flightSchedules = _airlineDBContext.Flights
                                                                    .Where(x => x.FromPlace == searchRequest.FromPlace &&
                                                                                x.ToPlace == searchRequest.ToPlace &&
                                                                                x.StartDateTime.Date>=searchRequest.StartDateTime.Date &&
                                                                                x.StartDateTime.Date<=searchRequest.EndDateTime.Date
                                                                                ).ToList();
              
            IEnumerable<Airline> airlines = _airlineDBContext.Airlines.ToList();

            var responsedata = (from flight in flightSchedules
                                join airline in airlines on flight.AirlineId equals airline.AirlineId
                                where airline.IsBlocked == 0
                                select new
                                {
                                    airline.AirlineName,
                                    flight.FlightId,
                                    flight.FlightNumber,
                                    flight.FromPlace,
                                    flight.ToPlace,
                                    flight.StartDateTime,
                                    flight.EndDateTime,
                                    flight.TicketCost
                                }).ToList();
           
            return Ok(responsedata);
        }


       
    }
}
