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

                userServices.SaveRefreshToken(userResponse.user.Id,accessToken.RefreshToken);
                return new TokenResponse(accessToken);

            }
            else
            {
                return new TokenResponse(userResponse.Message);
            }

        }

        public TokenResponse CreateAccesTokenByRefreshToken(string refreshToken)
        {
            UserResponse userResponse = userServices.GetUserWithRefreshToken(refreshToken);

            if (userResponse.Status)
            {
                //User response refreshtoken end date tarihi çağrıldı tarihten küçük olması lazım bunun kontrolü için
                if (userResponse.user.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccessToken(userResponse.user);
                  
                    userServices.SaveRefreshToken(userResponse.user.Id, accessToken.RefreshToken);

                    return new TokenResponse(accessToken);
                }
                else
                {
                    return new TokenResponse("Oturumunuzun Süresi Dolmuştur");
                }
            }
            else
            {
                return new TokenResponse("Oturum Bulunamadı");
            }
        }

        public TokenResponse RevokeRefreshToken(string refreshToken)
        {
            UserResponse userResponse = userServices.GetUserWithRefreshToken(refreshToken);
            if (userResponse.Status)
            {
                userServices.RemoveRefreshToken(userResponse.user);
                return new TokenResponse(new AccessToken());
            }
            else
            {
                return new TokenResponse("Oturum kapatılması Sorun Yaşanıldı: RefreshToken Bulunamadı");
            }

        }

        
    }
}
