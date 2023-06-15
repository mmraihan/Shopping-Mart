
using Microsoft.EntityFrameworkCore;
using ShoppingMart.Core.Entities;


namespace ShoppingMart.Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
     
    }
}
