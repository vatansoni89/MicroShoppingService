using MassTransit.Transports;
using MongoDB.Driver;
using Ordering.Infrastructure.Persistence;
using Shipping.Data.Interfaces;
using Shipping.Entities;
using Shipping.Exceptions;
using Shipping.Repositories.Interfaces;

namespace Shipping.Repositories
{
    public class ShipmentWriteRepository : RepositoryBase<Shipment>, IShipmentWriteRepository
    {

        public ShipmentWriteRepository(ShipmentWriteContext dbContext) : base(dbContext)
        {

        }
    }
}
