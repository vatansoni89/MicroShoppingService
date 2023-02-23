using AutoMapper;
using MediatR;
using MongoDB.Driver;
using Shipping.Data.Interfaces;
using Shipping.Entities;

namespace Shipping.CQRS.Queries.EventHandlers.Deleted
{
    public class DeletedShipmentEventHandler : IRequestHandler<DeletedShipment, bool>
    {
        private readonly IShippingReadContext _context;
        private readonly ILogger<DeletedShipmentEventHandler> _logger;

        public DeletedShipmentEventHandler(IShippingReadContext context, ILogger<DeletedShipmentEventHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeletedShipment request, CancellationToken cancellationToken)
        {
            FilterDefinition<Shipment> filter = Builders<Shipment>.Filter.Eq(p => p.Id, request.Id);

            DeleteResult deleteResult = await _context
                                                .Shipments
                                                .DeleteOneAsync(filter, cancellationToken);

            bool isSuccess = deleteResult.IsAcknowledged
                    && deleteResult.DeletedCount > 0;
            if (isSuccess)
                _logger.LogInformation($"Shipment {request.Id} is successfully deleted.");

            return isSuccess;
        }
    }
}
