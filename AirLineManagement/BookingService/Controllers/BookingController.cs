using BookingService.ViewModels;
using CoreModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AirlineDBContext _airlineDBContext;
        public BookingController(AirlineDBContext airlineDBContext)
        {
            _airlineDBContext = airlineDBContext;
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
            foreach (var passengerdata in bookingRequest.Passengers)
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
                                      booking.Pnr == currentBookingData.Pnr &&
                                      booking.BookingStatus == 1
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
                                    totalCost = flight.TicketCost * bookingrequestData.TotalSeat
                                }).ToList();

            return Ok(responsedata);
        }

        [HttpPost]
        [Route("cancel")]
        public IActionResult CancelBooking(int pnr)
        {
            try
            {
                Booking bookingData = _airlineDBContext.Bookings.Where(x => x.Pnr == pnr).FirstOrDefault();

                bookingData.BookingStatus = 0;

                _airlineDBContext.Update(bookingData);
                var x = _airlineDBContext.SaveChanges();

                if (x != 0)
                {
                    var message = "Booking for PNR No: " + pnr + " is cancelled successfully";
                    return Accepted(message);
                }
                else
                {
                    return Ok("No records found with PNR: " + pnr);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Response = "Error",
                    ResponseMessage = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("history")]
        public IActionResult BookingHistory(int userId)
        {

            IEnumerable<Booking> bookingData = _airlineDBContext.Bookings.Where(x=>x.UserId==userId).ToList();

            IEnumerable<Flight> flightData = _airlineDBContext.Flights.ToList();

            IEnumerable<Airline> airlineData = _airlineDBContext.Airlines.ToList();

            // IEnumerable<Passenger> passenggerData = _airlineDBContext.Passengers.ToList();

            var historyResult = (from booking in bookingData
                                 join flight in flightData on booking.FlightId equals flight.FlightId
                                 join airline in airlineData on flight.AirlineId equals airline.AirlineId
                                 where booking.UserId==userId
                                 select new
                                 {
                                     airlinename=airline.AirlineName,
                                     flight.FlightNumber,
                                     flight.FromPlace,
                                     flight.ToPlace,
                                     flight.StartDateTime,
                                     flight.EndDateTime,
                                     booking.BookingStatus,
                                     booking.Pnr,
                                     booking.TotalSeat,
                                     booking.IsOneway,
                                     TotalCost=booking.TotalSeat*flight.TicketCost                              }
                              ).ToList();



            return Ok(historyResult);
        }

    }
}
