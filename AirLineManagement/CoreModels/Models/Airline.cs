using System;
using System.Collections.Generic;

#nullable disable

namespace CoreModels.Models
{
    public partial class Airline
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string Logo { get; set; }
        public string ContactNumber { get; set; }
        public int? IsBlocked { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
