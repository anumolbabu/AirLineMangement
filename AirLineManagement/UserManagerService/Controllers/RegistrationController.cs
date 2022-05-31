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
    [Route("api/v1.0/registration")]
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
        public IActionResult Register(LoginUserData logedinuser)
        {
            try
            {
                User registereduser = _registrationService.Register(logedinuser);
                
                if (registereduser.UserId==0)
                {
                    return Ok("Registeration Failed");
                }
                var token = _JWTManager.Authenticate(logedinuser);
                if (token == null)
                {
                    return Unauthorized();
                }

                Dictionary<string, string> response = new Dictionary<string, string>();

                response.Add("UserId", registereduser.UserId.ToString());
                response.Add("UserName", registereduser.UserName.ToString());
                response.Add("Role",registereduser.Role.ToString());
                response.Add("Token", token.Token);
                response.Add("RefreshToken", token.RefreshToken);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    Response = "Error",
                    ResponseMessage = ex.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("findall")]
        public IActionResult FindAll()
        {
            return Ok("All Users");
        }
    }
}
