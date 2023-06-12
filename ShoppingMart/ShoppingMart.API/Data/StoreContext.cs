using Microsoft.EntityFrameworkCore;
using ShoppingMart.API.Entities;

namespace ShoppingMart.API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
