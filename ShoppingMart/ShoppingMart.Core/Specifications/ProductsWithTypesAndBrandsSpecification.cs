using ShoppingMart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMart.Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {      
            public ProductsWithTypesAndBrandsSpecification(string sort)
            {
                AddInclude(x => x.ProductType);
                AddInclude(x => x.ProductBrand);
                AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p=>p.Price); 
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p=>p.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
                

            }
            public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
            {
                AddInclude(x => x.ProductType);
                AddInclude(x => x.ProductBrand);
            }

    }
}
