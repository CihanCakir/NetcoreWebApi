using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjects.Domain.Response;

namespace WebApiProjects.Domain.Services
{
    public interface IProductServices
    {
        Task<ProductListRepsonse> ListAsync();

        Task<ProductResponse> AddProduct(Product product);

        Task<ProductResponse> RemoveProduct(int productId);

        Task<ProductResponse> UpdateResponse(Product product, int productId);

        Task<ProductResponse> FindByIdAsync(int productId);

    }
}
