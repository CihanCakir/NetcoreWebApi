﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProjects.Domain.Services;
using AutoMapper;
using WebApiProjects.Domain.Response;
using WebApiProjects.Resource;
using WebApiProjects.Extension;
using WebApiProjects.Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApiProjects.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;
        private readonly IMapper mapper;
        public ProductController(IProductServices productServices, IMapper mapper)
        {
            this.mapper = mapper;
            this.productServices = productServices;
        } 
       
        [HttpGet]
        public async Task<IActionResult> GetList()
        {

            ProductListRepsonse productListRepsonse = await productServices.ListAsync();

            if (productListRepsonse.Status)
            {
                return Ok(productListRepsonse.ProductList);
            }
            else
            {
                return BadRequest(productListRepsonse.Message);
            }
        }
      
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            ProductResponse product = await productServices.FindByIdAsync(Id);

            if (product.Status)
            {
                return Ok(product.Product);
            }
            else
            {
                return BadRequest(product.Message);
            }
        }
       
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());

            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                var response = await productServices.AddProduct(product);

                if (response.Status)
                {
                    return Ok(response.Product);
                }
                else
                {
                    return BadRequest(response.Message); 
                }
            }
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> UpdateProduct(ProductResource productResource, int Id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                var response = await productServices.UpdateProduct(product,Id);

                if (response.Status)
                {
                    return Ok(response.Product);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProduct(int Id)
        {
            ProductResponse productResponse = await productServices.RemoveProduct(Id);
            if (productResponse.Status)
            {
                return Ok(productResponse.Product);
            }
            else
            {
                return BadRequest(productResponse.Message);
            }

        }

    }
}