using System;
using System.Collections.Generic;

#nullable disable

namespace CoreModels.Models
{
    public partial class Airline
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public int? ContactNumber { get; set; }
        public string ContactAddress { get; set; }
        public int? IsBlocked { get; set; }
        public int? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
