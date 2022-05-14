using CoreModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginService.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;

        #region Constructors
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        #endregion

        [AllowAnonymous]
        [HttpPost]
        [Route("LogOn")]
        public IActionResult LogOn(User user)
        {

            if (!_loginService.LogOn(user))
            {
                return Unauthorized();
            }
            //var token = _JWTManager.Authenticate(user);
            //if (token == null)
            //{
            //    return Unauthorized();
            //}
            return Ok();

        }
    }
}
