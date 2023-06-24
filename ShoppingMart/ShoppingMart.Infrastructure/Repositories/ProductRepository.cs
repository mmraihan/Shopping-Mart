using Microsoft.EntityFrameworkCore;
using ShoppingMart.Core.Entities;
using ShoppingMart.Core.Interfaces;
using ShoppingMart.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMart.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

       
        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            //var typeId = 1;
            //var products = _context.Products
            //    .Where(c => c.Equals(typeId))
            //    .Include(c=>c.ProductType).ToListAsync();

            return await _context.Products
                .Include(p=>p.ProductType)
                .Include(p=>p.ProductBrand)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }
    }
}
