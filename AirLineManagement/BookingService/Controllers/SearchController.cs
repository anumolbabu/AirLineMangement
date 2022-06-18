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


        [HttpPost]
        [Route("bookflight")]
        public IActionResult BookFlight(BookingRequestModel bookingRequest)
        {
            Booking bookingrequestData = new Booking();
            bookingrequestData.FlightId = bookingRequest.FlightId;
            bookingrequestData.UserId = bookingRequest.UserId;
            bookingrequestData.IsOneway = bookingRequest.IsOneway;
            bookingrequestData.BookingStatus = 1;
            bookingrequestData.CreatedBy = bookingRequest.UserName;
            bookingrequestData.CreatedDate = System.DateTime.UtcNow;
            bookingrequestData.UpdatedBy = bookingRequest.UserName;
            bookingrequestData.UpdatedDate = System.DateTime.UtcNow;
            _airlineDBContext.Bookings.Add(bookingrequestData);

            _airlineDBContext.SaveChanges();

            Booking currentBookingData = _airlineDBContext.Bookings
                                                                .Where(x => x.FlightId == bookingrequestData.FlightId &&
                                                                            x.UserId == bookingrequestData.UserId &&
                                                                            x.BookingStatus == 1 &&
                                                                            x.CreatedDate == bookingrequestData.CreatedDate).FirstOrDefault();
                                                                
            

            Passenger passenger = new Passenger();
            foreach(var passengerdata in bookingRequest.Passengers)
            {

                passenger.Pnr = currentBookingData.Pnr;

                passenger.PassengerName = passengerdata.PassengerName;
                passenger.Age = passengerdata.Age;
                passenger.Gender = passengerdata.Gender;
                passenger.SeatNumber = passengerdata.SeatNumber;
                passenger.SeatType = passengerdata.SeatType;
                passenger.MealType = passengerdata.MealType;
                passenger.TicketCost = passengerdata.TicketCost;

                passenger.CreatedBy = bookingRequest.UserName;
                passenger.CreatedDate = System.DateTime.UtcNow;
                passenger.UpdatedBy = bookingRequest.UserName;
                passenger.UpdatedDate = System.DateTime.UtcNow;

                _airlineDBContext.Passengers.Add(passenger);
                _airlineDBContext.SaveChanges();
            }

            IEnumerable<Airline> airlineData = _airlineDBContext.Airlines.ToList();

            IEnumerable<Flight> flightData = _airlineDBContext.Flights.ToList();

            IEnumerable<Booking> bookingData = _airlineDBContext.Bookings.Where(x => x.Pnr == currentBookingData.Pnr).ToList();



            var responsedata = (from booking in bookingData
                                join flight in flightData on booking.FlightId equals flight.FlightId
                                join airline in airlineData on flight.AirlineId equals airline.AirlineId
                                where airline.IsBlocked == 0 &&
                                      booking.Pnr==currentBookingData.Pnr
                                select new
                                {
                                    airline.AirlineName,
                                    flight.FlightId,
                                    flight.FlightNumber,
                                    flight.FromPlace,
                                    flight.ToPlace,
                                    flight.StartDateTime,
                                    flight.EndDateTime,
                                    passengerCount = bookingrequestData.TotalSeat,
                                    totalCost =flight.TicketCost* bookingrequestData.TotalSeat
                                }).ToList();

            return Ok(responsedata);
        }
    }
}
