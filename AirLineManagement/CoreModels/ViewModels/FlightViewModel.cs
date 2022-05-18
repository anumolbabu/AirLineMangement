using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModels.ViewModels
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }
        public int FlightNumber { get; set; }
        public int AirlineId { get; set; }
        public string InstrumentUsed { get; set; }
        public int? BusinessClassSeatsCount { get; set; }
        public int TotalSeatsCount { get; set; }
        public int? NumberOfRows { get; set; }
    }
}
