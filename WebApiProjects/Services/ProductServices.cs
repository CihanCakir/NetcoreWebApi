using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjects.Domain;
using WebApiProjects.Domain.Repositories;
using WebApiProjects.Domain.Response;
using WebApiProjects.Domain.Services;
using WebApiProjects.Domain.UnitOfWork;

namespace WebApiProjects.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductServices(IProductRepository productRepository,IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            
        }
        public async Task<ProductResponse> AddProduct(Product product)
        {
            try
            {
                await productRepository.AddProductAsync(product);
                await unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception excepiton)
            {

                return new ProductResponse($"Ürün Eklerken bir hata oluştu {excepiton.Message}");
            }


        }

        public async Task<ProductResponse> FindByIdAsync(int productId)
        {
            try
            {
                Product product = await productRepository.FindByIdAsync(productId);

                if (product == null)
                {
                    return new ProductResponse("Ürün Bulunamadı");

                }
                return new ProductResponse(product);
            
            
            }
            catch (Exception exception)
            {

                return new ProductResponse($"Ürün Aramasında bir hata meydana geldi::{exception.Message}");
            }

        }

        public  async Task<ProductListRepsonse> ListAsync()
        {
            try
            {
                IEnumerable<Product> products = await productRepository.ListAsync();

                return new ProductListRepsonse(products);
            }
            catch (Exception exception)
            {
                return new ProductListRepsonse($"Ürün Listelinerken bir hata meydana geldi::{exception.Message}");
            }


        }

        public async Task<ProductResponse> RemoveProduct(int productId)
        {
            try
            {
                Product product = await productRepository.FindByIdAsync(productId);

                if (product == null)
                {
                    return new ProductResponse("Silmeye çalışılan ürün Bulunamadı");

                }
                await productRepository.RemoveProductAsync(productId);
                await unitOfWork.CompleteAsync();
                // Veritabanına şimdi uygula diyoruz unitofwork methodu ile
                return new ProductResponse(product);
             }
            catch (Exception exception)
            {
                return new ProductResponse($"Ürün Listelinerken bir hata meydana geldi::{exception.Message}");
            }

        }

        public async Task<ProductResponse> UpdateResponse(Product product, int productId)
        {
            try
            {
                var firstProduct = await productRepository.FindByIdAsync(productId);

                if(firstProduct == null)
                {
                    return new ProductResponse("Güncellenmeye çalışılan ürün Bulunamadı");
                }
                firstProduct.Name = product.Name;
                firstProduct.Category = product.Category;
                firstProduct.Price = product.Price;

                productRepository.UpdateProduct(firstProduct);


                await unitOfWork.CompleteAsync();

                return new ProductResponse(firstProduct);
            }
            catch (Exception exception)
            {

                return new ProductResponse($"Ürün Güncellenirken bir hata meydana Geldi::{exception.Message}");
            }

        }
    }
}