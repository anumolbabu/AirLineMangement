using CoreModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class FlightBookingController : ControllerBase
    {
        public FlightBookingController()
        {

        }

        public IActionResult Book(Flight flight)
        {
            return Ok();
        }
    }
}
