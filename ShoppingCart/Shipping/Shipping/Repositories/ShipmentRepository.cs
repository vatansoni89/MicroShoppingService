using MongoDB.Driver;
using Shipping.Data.Interfaces;
using Shipping.Entities;
using Shipping.Exceptions;
using Shipping.Repositories.Interfaces;

namespace Shipping.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly IShippingContext _context;

        public ShipmentRepository(IShippingContext context)
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

        public async Task<Shipment> GetShipment(string id)
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

        public async Task CreateShipment(Shipment shipment)
        {
            shipment.Id = Guid.NewGuid().ToString();
            var shipmentEntity = await GetShipmentsByOrderId(shipment.OrderId);
            if (shipmentEntity != null && shipmentEntity.Count > 0)
                throw new DuplicateException("Order", shipment.OrderId);
            await _context.Shipments.InsertOneAsync(shipment);
        }

        public async Task<bool> UpdateShipment(Shipment Shipment)
        {
            var updateResult = await _context
                                        .Shipments
                                        .ReplaceOneAsync(filter: g => g.Id == Shipment.Id, replacement: Shipment);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteShipment(string id)
        {
            FilterDefinition<Shipment> filter = Builders<Shipment>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Shipments
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
