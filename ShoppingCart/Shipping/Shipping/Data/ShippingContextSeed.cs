using MongoDB.Driver;
using Shipping.Entities;

namespace Shipping.Data
{
    public class ShippingContextSeed
    {
        public static void SeedShipmentData(IMongoCollection<Shipment> shipmentCollection)
        {
            bool existProduct = shipmentCollection.Find(p => true).Any();
            if (!existProduct)
            {
                shipmentCollection.InsertManyAsync(GetPreconfiguredShipments());
            }
        }
        private static IEnumerable<Shipment> GetPreconfiguredShipments()
        {
            return new List<Shipment>()
            {
                new Shipment()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedOnUtc=DateTime.UtcNow,
                    DeliveryDateUtc=DateTime.UtcNow.AddDays(7),
                    ShippedDateUtc=DateTime.UtcNow,
                    OrderId="1",
                    TrackingNumber="1",
                    TrackingUrl="",
                }
                ,new Shipment()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedOnUtc=DateTime.UtcNow,
                    DeliveryDateUtc=DateTime.UtcNow.AddDays(7),
                    ShippedDateUtc=DateTime.UtcNow,
                    OrderId="2",
                    TrackingNumber="2",
                    TrackingUrl="",
                }
                ,new Shipment()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedOnUtc=DateTime.UtcNow,
                    DeliveryDateUtc=DateTime.UtcNow.AddDays(7),
                    ShippedDateUtc=DateTime.UtcNow,
                    OrderId="3",
                    TrackingNumber="3",
                    TrackingUrl="",
                }
            };
        }
    }
}
