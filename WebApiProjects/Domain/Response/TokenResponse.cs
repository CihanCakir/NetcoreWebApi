using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjects.Security.Token;

namespace WebApiProjects.Domain.Response
{
    public class TokenResponse : BaseResponse
    {
       
        public AccessToken accessToken { get; set; }
        private TokenResponse(bool Status, string Message, AccessToken accessToken) : base(Status, Message)
        {
            this.accessToken = accessToken;
        }

        // Gişriş Sağlanır ise başarılı dönüşü yapılacak
        public TokenResponse(AccessToken accessToken) : this(true, string.Empty, accessToken) { }
        // Giriş Başarısız ise
        public TokenResponse(string message):this(false, message, null) { }

    }
}
