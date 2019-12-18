using Microsoft.AspNetCore.Mvc;
using WebApiProjects.Domain.Services;
using WebApiProjects.Resource;
using WebApiProjects.Extension;
using WebApiProjects.Domain.Response;
using System.Net.Http;
using System.IO;
using WebApiProjects.Domain;
using System.Net;
using System.Net.Http.Headers;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace WebApiProjects.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        string bookPath_Pdf = @"C:\Users\cihan\Downloads\nakitbasitexcel.csv";
        string bookPath_xls = @"C:\MyWorkSpace\SelfDev\UserAPI\UserAPI\Books\sample.xls";
        string bookPath_doc = @"C:\MyWorkSpace\SelfDev\UserAPI\UserAPI\Books\sample.doc";
        string bookPath_zip = @"C:\MyWorkSpace\SelfDev\UserAPI\UserAPI\Books\sample.zip";

        private readonly IAuthenticationServices authenticationServices;

        public LoginController(IAuthenticationServices authenticationServices)
        {
            this.authenticationServices = authenticationServices;
        }

       

        [HttpGet] //Returns FileStream if file exists 
        public IActionResult DownloadFile()
        {

            return null;
        }

        [HttpPost]
        public IActionResult AccessToken(LoginResource loginResource)
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