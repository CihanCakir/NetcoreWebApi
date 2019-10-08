using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjects.Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {

        public ProductRepository(WebApiContext context): base(context)
        {

        }
       
        public async Task AddProductAsync(Product product)
        {
            await context.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(int ProductId)
        {
            return await context.Product.FindAsync(ProductId);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Product.ToListAsync();
        }

        public async Task RemoveProductAsync(int ProductId)
        {
            var product = await FindByIdAsync(ProductId);

            context.Product.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            context.Product.Update(product);
        }
    }
}
