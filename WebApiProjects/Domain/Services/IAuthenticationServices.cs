using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjects.Domain.Response;

namespace WebApiProjects.Domain.Services
{
    public interface IAuthenticationServices
    {
        TokenResponse CreateAccessToken(string email, string Password);

        TokenResponse CreateAccesTokenByRefreshToken(string refreshToken);
        TokenResponse RevokeRefreshToken(string refreshToken);

    }
}
