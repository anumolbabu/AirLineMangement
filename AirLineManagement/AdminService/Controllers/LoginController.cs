using AdminService.Models;
using AdminService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTManagerRepository _JWTManager;
        private readonly ILoginService _loginService;
        public LoginController( ILoginService loginService, IJWTManagerRepository jWTManager)
        {
            _loginService = loginService;
            _JWTManager = jWTManager;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_loginService.FindAll());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User userdata)
        {
            var token = _JWTManager.Authenticate(userdata);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("LogOn")]
        public IActionResult LogOn(User user)
        {
            
            if (!_loginService.LogOn(user))
            {
                return Unauthorized();
            }
            var token = _JWTManager.Authenticate(user);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
            
        }
    }
}
