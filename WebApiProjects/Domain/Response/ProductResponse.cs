using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.Response
{
    public class ProductResponse : BaseResponse
    {
        public Product Product { get; set; }

        public ProductResponse(bool Status, string Message, Product product) : base(Status, Message)
        {
            this.Product = product;
        }

        // Başarılı olursa
        public ProductResponse(Product product) : this(true, string.Empty, product) { }

        //Başarısız olursa
        public ProductResponse(string message) : this(false, message, null) { }
    }
}
