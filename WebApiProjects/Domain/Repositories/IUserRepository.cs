using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);

        User FindById(int userId);

        User FindByEmailAndPassword(string email, string password);
        
        void SaveRefreshToken(int userId, string refreshToken);

        User GetUserWithRefreshToken(string refreshToken);

        void RemoveRefreshToken(User user);
        

    }
}
