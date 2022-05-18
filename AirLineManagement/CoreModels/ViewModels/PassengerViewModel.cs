using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModels.ViewModels
{
    public class PassengerViewModel
    {
        public int PassengerId { get; set; }
        public int? PnrNumber { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string MealId { get; set; }
        public int? SeatNumber { get; set; }
    }
}
