using MongoDB.Driver;
using Shipping.Entities;

namespace Shipping.Data.Interfaces
{
    public interface IShippingContext
    {
        IMongoCollection<Shipment> Shipments { get; }
    }
}
