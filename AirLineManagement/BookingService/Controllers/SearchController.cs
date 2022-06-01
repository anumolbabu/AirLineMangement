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


        [HttpPost]
        [Route("bookflight")]
        public IActionResult BookFlight(BookingRequestModel bookingRequest)
        {
            BookingDetail bookingData = new BookingDetail();
            bookingData.ScheduleId = bookingRequest.ScheduleId;
            bookingData.UserId = bookingRequest.UserId;
            bookingData.IsRoundTrip = 0;
            bookingData.BookingStatus = 1;
            bookingData.TotalPrice = bookingRequest.Ticketprice * bookingRequest.TotalSeat;
            bookingData.CreatedBy = "User";
            bookingData.CreatedDate = System.DateTime.UtcNow;
            _airLineDBContext.BookingDetails.Add(bookingData);

            _airLineDBContext.SaveChanges();

            BookingDetail currentBookingData = _airLineDBContext.BookingDetails
                                                                .Where(x => x.ScheduleId == bookingData.ScheduleId &&
                                                                            x.UserId == bookingData.UserId &&
                                                                            x.BookingStatus == 1 &&
                                                                            x.CreatedDate == bookingData.CreatedDate).FirstOrDefault();
                                                                
            

            Passenger passenger = new Passenger();
            foreach(var passengerdata in bookingRequest.Passengers)
            {
                passenger.PassengerName = passengerdata.PassengerName;
                passenger.Age = passengerdata.Age;
                passenger.Gender = passengerdata.Gender;
                passenger.PnrNumber = currentBookingData.PnrNumber;

                _airLineDBContext.Passengers.Add(passenger);
                _airLineDBContext.SaveChanges();
            }
            
            //IEnumerable<Flight> flightdetails = _airLineDBContext.Flights.ToList();
            //IEnumerable<Airline> airlinedetails = _airLineDBContext.Airlines.ToList();

            return Ok(currentBookingData);
        }
    }
}
