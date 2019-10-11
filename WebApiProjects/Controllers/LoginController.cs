using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProjects.Domain.Services;
using WebApiProjects.Resource;
using WebApiProjects.Extension;
using WebApiProjects.Domain.Response;

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
        public IActionResult AccesToken(LoginResource loginResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                TokenResponse tokenResponse = authenticationServices.CreateAccessToken(loginResource.Email, loginResource.Password);
                if (tokenResponse.Status)
                {
                    return Ok(tokenResponse.accessToken);
                }
                else
                {
                    return BadRequest(tokenResponse.Message);
                }
            }
        }
        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource)
        {
        TokenResponse tokenResponse = authenticationServices.CreateAccesTokenByRefreshToken(tokenResource.RefreshToken);
            if (tokenResponse.Status)
            {
                return Ok(tokenResponse.accessToken);
            }
            else
            {
                return BadRequest(tokenResponse.Message);
            }
        }
        [HttpPost]
        public IActionResult RemoveRefreshToken(TokenResource tokenResource)
        {
            TokenResponse tokenResponse = authenticationServices.RevokeRefreshToken(tokenResource.RefreshToken);
            if(tokenResponse.Status)
            {
                return Ok(tokenResponse.accessToken);
            }
            else
            {
                return BadRequest(tokenResponse.Message);
            }
        
        }
    }
}