using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.Response
{
    public class BaseResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public BaseResponse(bool Status, string Message)
        {
            this.Status = Status;
            this.Message = Message;
        }
    }
}
