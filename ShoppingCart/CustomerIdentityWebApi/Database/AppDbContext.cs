using Microsoft.EntityFrameworkCore;

namespace CustomerIdentityWebApi.Database

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

    }
}
