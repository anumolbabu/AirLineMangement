using System;
using System.Collections.Generic;

#nullable disable

namespace CoreModels.Models
{
    public partial class BookingDetail
    {
        public int PnrNumber { get; set; }
        public int? UserId { get; set; }
        public int? ScheduleId { get; set; }
        public int? BookingStatus { get; set; }
        public int? TotalPrice { get; set; }
        public int? IsRoundTrip { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
