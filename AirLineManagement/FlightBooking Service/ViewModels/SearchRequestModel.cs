using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.ViewModels
{
    public class SearchRequestModel
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public int IsRoundTrip { get; set; }
    }
}
