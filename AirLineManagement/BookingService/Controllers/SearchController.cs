using BookingService.DTOs;
using CoreModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly AirLineDBContext _airLineDBContext;
        public SearchController(AirLineDBContext airLineDBContext)
        {
            _airLineDBContext = airLineDBContext;
        }

        public IActionResult Search(SearchRequestDTO searchRequestDTO)
        {
            return Ok();
        }
    }
}
