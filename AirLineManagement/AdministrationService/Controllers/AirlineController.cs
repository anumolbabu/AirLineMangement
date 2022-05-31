﻿using AdministrationService.Interfaces;
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
        public async Task<IActionResult> AddAirlineAsync(Airline airLine)
        {
            if (!await _airlineService.Create(airLine))
            {
                return BadRequest("Failed to add Airline");
            }
            return Ok();
        }

        /// <summary>
        /// Edit Airline
        /// </summary>
        /// <param name="airLine">Details of airline</param>
        /// <returns></returns>
        [HttpPost]
        [Route("editairline")]
        public async Task<IActionResult> EditAirlineAsync(Airline airLine)
        {
            if (!await _airlineService.Edit(airLine))
            {
                return BadRequest("Failed to edit Airline");
            }
            return Ok();
        }

        /// <summary>
        /// Delete AirLine
        /// </summary>
        /// <param name="airLine"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAirLine(int airlineid)
        {
            if (!await _airlineService.Delete(airlineid))
            {
                return BadRequest("Failed to add Airline");
            }
            return Ok();
        }

        [HttpGet]
        [Route("getairlines")]
        public async Task<IActionResult> GetAll()
        {
            List<Airline> airlines = new List<Airline>();
            airlines = (List<Airline>)await _airlineService.GetAll();

            return Ok(airlines);
        }


        [HttpPost]
        [Route("getairlinebyid")]
        public async Task<IActionResult> GetAirline(int airlineid)
        {
            Airline airlines = new Airline();
            airlines = await _airlineService.GetById(airlineid);

            return Ok(airlines);
        }
    }
}