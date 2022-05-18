using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CoreModels.Models
{
    public partial class Airline
    {
        [ScaffoldColumn(false)]
        public int AirlineId { get; set; }

        public string AirlineName { get; set; }

        public int? IsBlocked { get; set; }

        public int? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
