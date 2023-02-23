using MongoDB.Driver;
using Shipping.Entities;
using Shipping.Data.Interfaces;

namespace Shipping.Data
{
    public class ShippingReadContext : IShippingReadContext
    {
        public ShippingReadContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Shipments = database.GetCollection<Shipment>(configuration.GetValue<string>("DatabaseSettings:ShipmentCollection"));
            ShippingReadContextSeed.SeedShipmentData(Shipments);
        }

        public IMongoCollection<Shipment> Shipments { get; }
    }
}
