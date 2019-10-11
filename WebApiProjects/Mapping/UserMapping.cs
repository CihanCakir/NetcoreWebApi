using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjects.Domain;
using WebApiProjects.Resource;

namespace WebApiProjects.Mapping
{
    public class UserMapping :Profile
    {

        public UserMapping()
        {
            CreateMap<UserResource, User>();

            CreateMap<User, UserResource>();
        }
    }
}
