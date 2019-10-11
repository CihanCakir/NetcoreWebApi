using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjects.Domain.Response;
using WebApiProjects.Domain.Services;
using WebApiProjects.Security.Token;

namespace WebApiProjects.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUserServices userServices;
        private readonly ITokenHandler tokenHandler;

        public AuthenticationServices(IUserServices userServices, ITokenHandler tokenHandler)
        {
            this.tokenHandler = tokenHandler;
            this.userServices = userServices;
        }

        public TokenResponse CreateAccessToken(string email, string Password)
        {
            //kullanıcının olup olmadigini kontorl etmek icin userservices kullanıyoruz.
            UserResponse userResponse = userServices.FindByEmailAndPassword(email, Password);
            if (userResponse.Status)
            {
                AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.user);
                return new TokenResponse(accessToken);

            }
            else
            {
                return new TokenResponse(userResponse.Message);
            }

        }

        public TokenResponse CreateAccesTokenByRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public TokenResponse RevokeRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        
    }
}
