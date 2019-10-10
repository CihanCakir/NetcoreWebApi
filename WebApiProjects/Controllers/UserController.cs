using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProjects.Domain.Response;
using WebApiProjects.Domain.Services;
using WebApiProjects.Resource;

namespace WebApiProjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;
        private readonly IMapper mapper;

        public UserController(IUserServices userServices, IMapper mapper)
        {
            this.mapper = mapper;
            this.userServices = userServices;
        }

        [Authorize]
        public IActionResult GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;
            string userId = claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value;

            UserResponse user = userServices.FindById(int.Parse(userId));

            if (user.Status)
            {
                return Ok(user.user);
            }
            else
            {
                return BadRequest(user.Message);
            }


        }
        [AllowAnonymous]
        public IActionResult AddUser(UserResource userResource)
        {
            return Ok();
        }
    }
}