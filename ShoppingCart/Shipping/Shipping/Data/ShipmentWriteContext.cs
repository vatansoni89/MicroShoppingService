using Microsoft.EntityFrameworkCore;
using Shipping.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class ShipmentWriteContext : DbContext
    {
        public ShipmentWriteContext(DbContextOptions<ShipmentWriteContext> options) : base(options)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shipment>().ToTable("Shipments");
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Shipment>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOnUtc = DateTime.UtcNow;
                        entry.Entity.LastModifiedOnUtc = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOnUtc = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
