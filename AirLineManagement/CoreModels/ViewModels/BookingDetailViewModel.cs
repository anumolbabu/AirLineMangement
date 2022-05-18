using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModels.ViewModels
{
    /// <summary>
    /// ViewModel BookingDetail
    /// </summary>
    public class BookingDetailViewModel
    {
        public int PnrNumber { get; set; }
        public int? UserId { get; set; }
        public int? FlightId { get; set; }
        public int? BookingStatus { get; set; }
    }
}
