using AdministrationService.Interfaces;
using CoreModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministrationService.Controllers
{
    /// <summary>
    /// AirLine Controller
    /// </summary>
    [Route("api/v1.0/airline")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineService _airlineService;

        /// <summary>
        /// Initializes new instance <cref=AirLineController></cref>
        /// </summary>
        /// <param name="airlineService"></param>
        public AirlineController(IAirlineService airlineService)
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
            if (! _airlineService.Create(airLine))
            {
                return BadRequest("Failed to add Airline");
            }
            return Ok(airLine);
        }

        /// <summary>
        /// Edit Airline
        /// </summary>
        /// <param name="airLine">Details of airline</param>
        /// <returns></returns>
        [HttpPost]
        [Route("editairline")]
        public IActionResult EditAirlineAsync(Airline airLine)
        {
            if (! _airlineService.Edit(airLine))
            {
                return BadRequest("Failed to edit Airline");
            }
            return Ok(airLine);
        }

        /// <summary>
        /// Delete AirLine
        /// </summary>
        /// <param name="airlineid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteAirLine(int id)
        {
            if (! _airlineService.Delete(id))
            {
                return BadRequest("Failed to add Airline");
            }
            return Ok();
        }

        [HttpGet]
        [Route("getairlines")]
        public IActionResult GetAll()
        {
            List<Airline> airlines = new List<Airline>();
            airlines = (List<Airline>) _airlineService.GetAll();

            return Ok(airlines);
        }


        [HttpPost]
        [Route("getairlinebyid")]
        public IActionResult GetAirline(int airlineid)
        {
            Airline airlines = new Airline();
            airlines =  _airlineService.GetById(airlineid);

            return Ok(airlines);
        }
    }
}
