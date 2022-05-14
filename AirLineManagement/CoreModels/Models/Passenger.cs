using System;
using System.Collections.Generic;

#nullable disable

namespace CoreModels.Models
{
    public partial class Passenger
    {
        public int PassengerId { get; set; }
        public int? PnrNumber { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string MealId { get; set; }
        public int? SeatNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
