using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModels.ViewModels
{
    /// <summary>
    /// ViewModel  Airline
    /// </summary>
    public class AirlineViewModel
    {
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public int? IsBlocked { get; set; }
    }
}
