using System;
using System.Collections.Generic;

#nullable disable

namespace CoreModels.Models
{
    public partial class Flight
    {
        public int FlightId { get; set; }
        public int FlightNumber { get; set; }
        public int AirlineId { get; set; }
        public string InstrumentUsed { get; set; }
        public int? BusinessClassSeatsCount { get; set; }
        public int? NumberOfRows { get; set; }
        public int TotalSeatsCount { get; set; }
        public int? IsMealOpted { get; set; }
        public int? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Createddate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpadatedDate { get; set; }
    }
}
