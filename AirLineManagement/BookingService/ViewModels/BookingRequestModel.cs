using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.ViewModels
{
    public class BookingRequestModel
    {
        public int FlightId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public int IsOneway { get; set; }

        public int? BookingStatus { get; set; }

        public int TotalSeat { get; set; }

        public List<Passenger> Passengers {get; set;}
    }
}
