using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStore.Models.Data
{
    public class ElectronicStoreContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        
        public ElectronicStoreContext(DbContextOptions options) : base(options)
        {
        }
    }
}