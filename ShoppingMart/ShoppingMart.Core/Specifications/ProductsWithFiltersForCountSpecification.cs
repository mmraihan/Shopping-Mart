﻿using ShoppingMart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMart.Core.Specifications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams) : base(x =>
             (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
             (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {

        }
    }
}
