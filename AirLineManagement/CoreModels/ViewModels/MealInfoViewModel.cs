using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModels.ViewModels
{
    public class MealInfoViewModel
    {
        public int? MealId { get; set; }
        public int? FlightId { get; set; }
        public string MealType { get; set; }
        public string MealName { get; set; }
    }
}
