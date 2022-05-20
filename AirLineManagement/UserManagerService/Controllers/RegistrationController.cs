using CoreModels.Models;
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
    public class RegistrationController : ControllerBase
    {
        private readonly IJWTManagerService _JWTManager;
        IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService, IJWTManagerService jWTManagerRepository)
        {
            _registrationService = registrationService;
            _JWTManager = jWTManagerRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register(LoginViewModel logedinuser)
        {
            try
            {
                User registereduser = _registrationService.Register(logedinuser);
                var token = _JWTManager.Authenticate(logedinuser);
                if (token == null)
                {
                    return Unauthorized();
                }
                RegisterResponse response = new RegisterResponse
                {
                    User = registereduser,
                    Tokens = token
                };
               
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
