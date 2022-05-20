using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.DTOs
{
    public class FlightBookingResponseDTO
    {
        public List<Flight> Flights { get; set; }
        public List<Airline> Airlines  { get; set; }
    }
}
