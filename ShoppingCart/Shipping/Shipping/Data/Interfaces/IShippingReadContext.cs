using MongoDB.Driver;
using Shipping.Entities;

namespace Shipping.Data.Interfaces
{
    public interface IShippingReadContext
    {
        IMongoCollection<Shipment> Shipments { get; }
    }
}
