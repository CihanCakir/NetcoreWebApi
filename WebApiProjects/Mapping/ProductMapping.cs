using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApiProjects.Domain;
using WebApiProjects.Resource;

namespace WebApiProjects.Mapping
{
    public class ProductMapping :Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductResource, Product>();

            CreateMap<Product, ProductResource>();
        }
    }
}
