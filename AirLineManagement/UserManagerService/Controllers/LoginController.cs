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
    [Route("api/v1.0/login")]
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
       

        [AllowAnonymous]
        [HttpPost]
        [Route("logon")]
        public IActionResult LogOn(LoginUserData loggedinuser)
        {
            List<string> result = _loginService.LogOn(loggedinuser);
            if(result.Count==0)
            {
                return Ok("EmailId or Password incorrect");
            }
            var token = _JWTManager.Authenticate(loggedinuser.Email);
            if (token == null)
            {
                return Unauthorized();
            }

            Dictionary<string, string> response = new Dictionary<string, string>();

            response.Add("UserId", result[0].ToString());
            response.Add("Email", result[1].ToString());
            response.Add("Name", result[2].ToString());
            response.Add("Role", result[3].ToString());

            //response.Add("Gender", result[4].ToString());
            //response.Add("Age", result[5].ToString());
            //response.Add("ContactNumber", result[6].ToString());

            response.Add("Token", token.Token);
            response.Add("RefreshToken", token.RefreshToken);
            return Ok(response);
        }
    }
}
