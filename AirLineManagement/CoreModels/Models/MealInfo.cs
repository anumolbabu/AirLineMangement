using System;
using System.Collections.Generic;

#nullable disable

namespace CoreModels.Models
{
    public partial class MealInfo
    {
        public int? MealId { get; set; }
        public int? FlightId { get; set; }
        public string MealType { get; set; }
        public string MealName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
