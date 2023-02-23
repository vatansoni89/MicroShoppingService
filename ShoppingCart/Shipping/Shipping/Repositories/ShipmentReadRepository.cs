using MongoDB.Driver;
using Shipping.Data.Interfaces;
using Shipping.Entities;
using Shipping.Exceptions;
using Shipping.Repositories.Interfaces;

namespace Shipping.Repositories
{
    public class ShipmentReadRepository : IShipmentReadRepository
    {
        private readonly IShippingReadContext _context;

        public ShipmentReadRepository(IShippingReadContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Shipment>> GetShipments()
        {
            return await _context
                            .Shipments
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<Shipment> GetShipment(int id)
        {
            return await _context
                           .Shipments
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<List<Shipment>> GetShipmentsByOrderId(string orderId)
        {
            return await _context
                            .Shipments
                             .Find(p => p.OrderId == orderId)
                            .ToListAsync();
        }

    }
}
