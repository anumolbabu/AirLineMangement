using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModels.ViewModels
{
    public class ScheduleViewModel
    {
        public int ScheduleId { get; set; }
        public int FlightId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public int? TicketCost { get; set; }
        public int? MealId { get; set; }
    }
}
