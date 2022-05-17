using AdminService.Services;
using CoreModels.Models;
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
    public class RegistrationController : ControllerBase
    {
        private readonly IJWTManagerRepository _JWTManager;
        IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService, IJWTManagerRepository jWTManagerRepository)
        {
            _registrationService = registrationService;
            _JWTManager = jWTManagerRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            int status=_registrationService.Register(user);
            if(status==0)
            {
                return Ok("Registration failed");
            }
            else
            {
                var token = _JWTManager.Authenticate(user);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            
        }
    }
}
