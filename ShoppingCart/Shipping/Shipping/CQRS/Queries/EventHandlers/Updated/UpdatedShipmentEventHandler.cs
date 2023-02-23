using AutoMapper;
using MediatR;
using Shipping.Data.Interfaces;
using Shipping.Entities;
using MongoDB.Driver;

namespace Shipping.CQRS.Queries.EventHandlers.Updated
{
    public class UpdatedShipmentEventHandler : IRequestHandler<UpdatedShipment, bool>
    {
        private readonly IShippingReadContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatedShipmentEventHandler> _logger;

        public UpdatedShipmentEventHandler(IShippingReadContext context, IMapper mapper, ILogger<UpdatedShipmentEventHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdatedShipment request, CancellationToken cancellationToken)
        {
            var shipment = _mapper.Map<Shipment>(request);
            var updateResult = await _context
                                       .Shipments
                                       .ReplaceOneAsync(filter: g => g.Id == shipment.Id, replacement: shipment, cancellationToken: cancellationToken);
            bool isSuccess = updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
            if (isSuccess)
                _logger.LogInformation($"Shipment {shipment.Id} is successfully updated.");

            return isSuccess;
        }
    }
}
