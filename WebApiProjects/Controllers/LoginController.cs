using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProjects.Domain.Services;

namespace WebApiProjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationServices authenticationServices;

        public LoginController(IAuthenticationServices authenticationServices)
        {
            this.authenticationServices = authenticationServices;
        }
        [HttpPost]
        public IActionResult AccesToken()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult RefreshToken()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult RemoveRefreshToken()
        {
            return Ok();
        }
    }
}