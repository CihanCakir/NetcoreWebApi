using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserServices userServices,IMapper mapper)
        {
            this.mapper = mapper;
            this.userServices = userServices;
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok();
        }
        
        public IActionResult AddUser(UserResource userResource)
        {
            return Ok();
        }
    }
}