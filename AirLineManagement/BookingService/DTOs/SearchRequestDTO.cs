using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.DTOs
{
    public class SearchRequestDTO
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }

        
    }
}
