using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.ViewModels
{
    public class BookingRequestModel
    {
        public int ScheduleId { get; set; }

        public int UserId { get; set; }

        public int Ticketprice { get; set; }

        public int TotalSeat { get; set; }

        public List<Passenger> Passengers {get; set;}
    }
}
