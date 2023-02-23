using MongoDB.Driver;
using Shipping.Entities;

namespace Shipping.Data
{
    public class ShippingReadContextSeed
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
