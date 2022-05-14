using System;
using System.Collections.Generic;

#nullable disable

namespace CoreModels.Models
{
    public partial class Schedule
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
