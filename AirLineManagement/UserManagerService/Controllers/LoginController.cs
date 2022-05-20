using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagerService.Interfaces;
using UserManagerService.ViewModels;

namespace UserManagerService.Controllers
{
    [Authorize]
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTManagerService _JWTManager;
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService, IJWTManagerService jWTManager)
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
        public IActionResult Authenticate(LoginViewModel userdata)
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
        public IActionResult LogOn(LoginViewModel logedinuser)
        {
            if (!_loginService.LogOn(logedinuser))
            {
                return Unauthorized();
            }
            var token = _JWTManager.Authenticate(logedinuser);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
