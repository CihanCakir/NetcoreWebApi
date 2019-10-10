using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjects.Domain.Response;

namespace WebApiProjects.Domain.Services
{
    public interface IUserServices
    {
        UserResponse AddUser(User user);
        UserResponse FindById(int userId);
        UserResponse FindByEmailAndPassword(string email, string password);
        void SaveRefreshToken(int userId, string refreshtoken);
        UserResponse GetUserWithRefreshToken(string refreshtoken);
        void RemoveRefreshToken(User user);
    }
}
