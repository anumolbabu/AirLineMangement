using System;
using System.Collections.Generic;

#nullable disable

namespace CoreModels.Models
{
    public partial class Flight
    {
        public int FlightId { get; set; }
        public int? AirlineId { get; set; }
        public string FlightNumber { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string InstrumentUsed { get; set; }
        public int? BusinessClassSeats { get; set; }
        public int? NonBusinessClassSeats { get; set; }
        public int? RemainingBc { get; set; }
        public int? RemainingNonBc { get; set; }
        public int? TicketCost { get; set; }
        public int? NumberOfRows { get; set; }
        public string IsMealAvailable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
