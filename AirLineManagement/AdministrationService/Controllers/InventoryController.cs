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
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        /// <summary>
        /// Add Inventory
        /// </summary>
        /// <param name="flight">Inventory Details</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public IActionResult AddInventory(Flight flight)
        {
            Flight flightdata = _inventoryService.Create(flight);
            if(flightdata==null)
            {
                return BadRequest("Failed to add Inventory");
            }
            return Ok(flightdata);
        }

        /// <summary>
        /// Edit Inventory
        /// </summary>
        /// <param name="flight">Inventory Details</param>
        /// <returns></returns>
        [HttpPost]
        [Route("edit")]
        public IActionResult EditInventory(Flight flight)
        {
            Flight flightdata = _inventoryService.Edit(flight);
            if(flightdata==null)
            {
                return BadRequest("Failed to edit inventory");
            }
            return Ok(flightdata);
        }

        /// <summary>
        /// Delete inventory
        /// </summary>
        /// <param name="flightid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteInventory(int flightid)
        {
            if (!_inventoryService.Delete(flightid))
            {
                return BadRequest("Failed to delete inventory");
            }
            return Ok();
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            List<Flight> flights = new List<Flight>();
            flights = (List<Flight>)_inventoryService.GetAll();

            return Ok(flights);
        }


        [HttpPost]
        [Route("getbyid")]
        public IActionResult GetInventory(int flightid)
        {
            Flight flights = new Flight();
            flights = _inventoryService.GetById(flightid);

            return Ok(flights);
        }
    }
}
