using Microsoft.EntityFrameworkCore;
using Ordering.Infrastructure.Persistence;
using Shipping.Entities;

namespace Shipmenting.Infrastructure.Persistence
{
    public class ShipmentWriteContextSeed
    {
        public static async Task SeedAsync(ShipmentWriteContext ShipmentContext, ILogger<ShipmentWriteContextSeed> logger)
        {
            if (!ShipmentContext.Shipments.Any())
            {
                using (var transaction = ShipmentContext.Database.BeginTransaction())
                {
                    ShipmentContext.Shipments.AddRange(GetPreconfiguredShipments());
                    await ShipmentContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Shipments ON;");
                    await ShipmentContext.SaveChangesAsync();
                    await ShipmentContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Shipments OFF");
                    transaction.Commit();
                }
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ShipmentWriteContext).Name);
            }
        }

        private static IEnumerable<Shipment> GetPreconfiguredShipments()
        {
            return new List<Shipment>()
            {
                new Shipment()
                {
                    Id = 1,
                    DeliveryDateUtc=DateTime.UtcNow.AddDays(7),
                    ShippedDateUtc=DateTime.UtcNow,
                    OrderId="1",
                    TrackingNumber="1",
                    TrackingUrl="",
                    CreatedOnUtc=DateTime.UtcNow,
                    LastModifiedOnUtc=DateTime.UtcNow
                }
                ,new Shipment()
                {
                    Id = 2,
                    DeliveryDateUtc=DateTime.UtcNow.AddDays(7),
                    ShippedDateUtc=DateTime.UtcNow,
                    OrderId="2",
                    TrackingNumber="2",
                    TrackingUrl="",
                    CreatedOnUtc=DateTime.UtcNow,
                    LastModifiedOnUtc=DateTime.UtcNow
                }
                ,new Shipment()
                {
                    Id = 3,
                    DeliveryDateUtc=DateTime.UtcNow.AddDays(7),
                    ShippedDateUtc=DateTime.UtcNow,
                    OrderId="3",
                    TrackingNumber="3",
                    TrackingUrl="",
                    CreatedOnUtc=DateTime.UtcNow,
                    LastModifiedOnUtc=DateTime.UtcNow
                }
            };
        }
    }
}
