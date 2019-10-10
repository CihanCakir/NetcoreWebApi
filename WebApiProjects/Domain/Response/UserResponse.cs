using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.Response
{
    public class UserResponse : BaseResponse 
    {
        public User user { get; set; }

        public UserResponse(Boolean status,string message,User  user ):base(status,message)
        {
            this.user = user;
        }

        // işlem Başarılı ise
        public UserResponse(User user) : this(true, string.Empty, user) { }
        //İşlem Başarısız ise 
        public UserResponse(string message): this(false, message, null) { }
    }
}
