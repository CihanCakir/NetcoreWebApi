using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.Response
{
    public class ProductListRepsonse : BaseResponse
    {
        public IEnumerable<Product> ProductList { get; set; }
        private ProductListRepsonse(bool Status, string Message, IEnumerable<Product> products) : base(Status, Message)
        {
            this.ProductList = products;
        }


        //Başarılı olursa

        public ProductListRepsonse(IEnumerable<Product> products) : this(true, string.Empty, products)
        {

        }

        //Başarısız Olursa 
        public ProductListRepsonse(string message) : this(false, message, null)
        {

        }
    }
}
