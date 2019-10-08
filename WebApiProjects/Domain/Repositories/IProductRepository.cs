using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();

        Task AddProductAsync(Product product);

        Task RemoveProductAsync(int ProductId);

        void UpdateProduct(Product product);

        Task<Product> FindByIdAsync(int ProductId); 


    }
}
