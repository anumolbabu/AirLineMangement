using CoreModels.Models;
using FlightBookingService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Controllers
{
    [Route("api/v1.0/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly AirLineDBContext _airLineDBContext;
        public SearchController(AirLineDBContext airLineDBContext)
        {
            _airLineDBContext = airLineDBContext;
        }

        [HttpPost]
        [Route("searchflights")]
        public IActionResult Search(SearchRequestModel searchRequest)
        {
            IEnumerable<Schedule> flightSchedule = _airLineDBContext.Schedules
                                                                    .Where(x => x.FromPlace == searchRequest.FromPlace &&
                                                                                x.ToPlace == searchRequest.ToPlace &&
                                                                                x.StartDateTime.Date>=searchRequest.StartDateTime.Date &&
                                                                                x.StartDateTime.Date<=searchRequest.EndDateTime.Date
                                                                                ).ToList();
                                                                               
            IEnumerable<Flight> flightdetails = _airLineDBContext.Flights.ToList();
            IEnumerable<Airline> airlinedetails = _airLineDBContext.Airlines.ToList();

            var responsedata = (from schedule in flightSchedule
                                join flight in flightdetails on schedule.FlightId equals flight.FlightId
                                join airline in airlinedetails on flight.AirlineId equals airline.AirlineId
                                where airline.IsBlocked == 0
                                select new
                                {
                                    airline.AirlineName,
                                    flight.FlightNumber,
                                    schedule.ScheduleId,
                                    schedule.FromPlace,
                                    schedule.ToPlace,
                                    schedule.StartDateTime,
                                    schedule.EndDateTime,
                                    schedule.TicketCost
                                }).ToList();
           
            return Ok(responsedata);
        }
    }
}
