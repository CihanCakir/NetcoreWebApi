﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
namespace WebApiProjects.Resource
{
    public class ProductResource
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
    }
}