using System;
using System.Collections.Generic;

#nullable disable

namespace CoreModels.Models
{
    public partial class Passenger
    {
        public int PassengerId { get; set; }
        public int Pnr { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public int? SeatNumber { get; set; }
        public string SeatType { get; set; }
        public string MealType { get; set; }
        public int? TicketCost { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
