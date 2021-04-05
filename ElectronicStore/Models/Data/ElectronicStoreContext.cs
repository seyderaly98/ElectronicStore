using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStore.Models.Data
{
    public class ElectronicStoreContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<RecommendedProduct> RecommendedProducts { get; set; }
        public DbSet<CategoriesMonth> CategoriesMonth { get; set; }
        
        public ElectronicStoreContext(DbContextOptions options) : base(options)
        {
        }
    }
}