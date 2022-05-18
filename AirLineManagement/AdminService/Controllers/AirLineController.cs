using AdminService.Interfaces;
using CoreModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Controllers
{
    /// <summary>
    /// AirLine Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AirLineController : ControllerBase
    {
        private readonly IAirlineService _airlineService;

        /// <summary>
        /// Initializes new instance <cref=AirLineController></cref>
        /// </summary>
        /// <param name="airlineService"></param>
        public AirLineController(IAirlineService airlineService)
        {
            _airlineService = airlineService;
        }

        /// <summary>
        /// Add Airline
        /// </summary>
        /// <param name="airLine">Details of airline</param>
        /// <returns></returns>
        [HttpPost]
        [Route("addairline")]
        public IActionResult AddAirline(Airline airLine)
        {
           if(!_airlineService.AddAirline())
            {
                return BadRequest("Failed to add Airline");
            }
            return Ok();
        }


    }
}
