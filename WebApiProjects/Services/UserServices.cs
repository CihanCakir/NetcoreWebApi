using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjects.Domain;
using WebApiProjects.Domain.Repositories;
using WebApiProjects.Domain.Response;
using WebApiProjects.Domain.Services;
using WebApiProjects.Domain.UnitOfWork;

namespace WebApiProjects.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserServices(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public UserResponse AddUser(User user)
        {
            try
            {
                userRepository.AddUser(user);
                unitOfWork.Complete();
                return new UserResponse(user);
            }
            catch (Exception exception)
            {

                return new UserResponse($"Kullanıcı Eklenirken Bir hata Meydana geldi:{exception.Message}");
            }

        }

        public UserResponse FindById(int userId)
        {
            try
            {

                User user = userRepository.FindById(userId);
                if (user == null)
                {
                    return new UserResponse("Kullanıcı Bulunamadı");

                }
                return new UserResponse(user);
            }
            catch (Exception exception)
            {
                return new UserResponse($"Kullanıcı Aranırken bir Hata Oluştu : {exception.Message}");
            }

        }

        public UserResponse FindByEmailAndPassword(string email, string password)
        {

            try
            {
                User user = userRepository.FindByEmailAndPassword(email, password);
                if (user == null)
                {
                    return new UserResponse("Kullanıcı Bulunamadı");
                }
                return new UserResponse(user);
            }
            catch (Exception exception)
            {
                return new UserResponse($"Kullanıcıyı bulunurken bir hata meydana geldi:{exception.Message}");

            }


        }

        public void SaveRefreshToken(int userId, string refreshtoken)
        {
            try
            {
                userRepository.SaveRefreshToken(userId, refreshtoken);
                unitOfWork.Complete();
            }
            catch (Exception excep)
            {
              new UserResponse($"Hata Bağlanırken bir hata:{excep.Message}");
            }
        }

        public UserResponse GetUserWithRefreshToken(string refreshtoken)
        {
            try
            {
                User user = userRepository.GetUserWithRefreshToken(refreshtoken);
                if (user== null)
                {
                    return new UserResponse("User Token Exception");
                }
                return new UserResponse(user);
            }
            catch (Exception exception)
            {

                return new UserResponse($"Token could not connection server:{exception.Message}");
            }    
        }

        public void RemoveRefreshToken(User user)
        {
            try
            {
                userRepository.RemoveRefreshToken(user);
                unitOfWork.Complete();

            }
            catch (Exception excep)
            {
                new UserResponse($"Token Cant Remove Server Problem :{excep.Message}");
            }
        }

    }
}
