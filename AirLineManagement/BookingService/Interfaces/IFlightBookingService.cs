using BookingService.DTOs;
using BookingService.ViewModels;
using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Interfaces
{
    public interface IFlightBookingService
    {
        FlightBookingResponseDTO BookFlights(FlightBookingRequestDTO flightids);
    }
}
