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
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public readonly IFlightServices _flightServices;

        public FlightController(IFlightServices flightServices)
        {
            _flightServices = flightServices;
        }
        [HttpPost]
        [Route("addflight")]
        public async Task<IActionResult> AddFlightAsync(Flight flight)
        {
            if (!await _flightServices.Create(flight))
            {
                return BadRequest("Failed to add Flight");
            }
            return Ok();
        }

        [HttpPost]
        [Route("editflight")]
        public async Task<IActionResult> EditFlightAsync(Flight flight)
        {
            if (!await _flightServices.Edit(flight))
            {
                return BadRequest("Failed to edit Flight");
            }
            return Ok();
        }

        /// <summary>
        /// Delete Flight
        /// </summary>
        /// <param name="flightid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteflight")]
        public async Task<IActionResult> DeleteFlight(int flightid)
        {
            if (!await _flightServices.Delete(flightid))
            {
                return BadRequest("Failed to add Flight");
            }
            return Ok();
        }

        [HttpGet]
        [Route("getflights")]
        public async Task<IActionResult> GetAll()
        {
            List<Flight> flights = new List<Flight>();
            flights = (List<Flight>)await _flightServices.GetAll();

            return Ok(flights);
        }


        [HttpPost]
        [Route("getflightbyid")]
        public async Task<IActionResult> GetFight(int flightid)
        {
            Flight flight = new Flight();
            flight = await _flightServices.GetById(flightid);

            return Ok(flight);
        }
    }
}
